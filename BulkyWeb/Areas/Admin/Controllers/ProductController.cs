using BookNook.DataAccess.Repository.IRepository;
using BookNook.Models;
using BookNook.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;



namespace BookNookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitUnitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitUnitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string includeProperties = "Category";
            List<Product> Products = _unitUnitOfWork.ProductRepo.GetAll(includeProperties).ToList();

            return View(Products);
        }

        public IActionResult Upsert(int? id)
        {
            
            ProductVM ProductVM = new ProductVM();
            ProductVM.Categories = _unitUnitOfWork.CategoryRepo.GetAll();

            if(id == null || id == 0)
            {
                // create
                ProductVM.Product = new Product();
            }
            else
            {
                // update
                ProductVM.Product = _unitUnitOfWork.ProductRepo.Get(o=>o.Id == id);
            }

            return View(ProductVM);

        }
        [HttpPost]
        public IActionResult Upsert(ProductVM ProductVM, List<IFormFile>? files)
        {
            if(ModelState.IsValid)
            {
                // create
                if (ProductVM.Product.Id.ToString() == null || ProductVM.Product.Id == 0)
                {
                    _unitUnitOfWork.ProductRepo.Add(ProductVM.Product);
                    _unitUnitOfWork.Save();
                    TempData["success"] = "Product added successfully!";
                    // Save Images
                    if (files.Count > 0)
                    {
                        AddProductImages(files, ProductVM.Product.Id);
                    }
                }
                // Update
                else
                {
                    // Check if there are new images coming
                    if (files.Count > 0)
                    {
                        DeleteProductImages(ProductVM.Product.Id);

                        // Add new images
                        AddProductImages(files, ProductVM.Product.Id);
                        
                    }

                    _unitUnitOfWork.ProductRepo.Update(ProductVM.Product);
                    _unitUnitOfWork.Save();
                    TempData["success"] = "Product updated successfully!";
                }
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error happened, please try again.";
            return RedirectToAction("Upsert", ProductVM);

        }
        

        private void AddProductImages(List<IFormFile> files, int id)
        {
            // save images to folder products

            List<ProductImage> ImagesList = new List<ProductImage>();
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = "";
            string saveFolderPath = Path.Combine(wwwRootPath, @"images\products");
            foreach (var file in files)
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                using (var fileStream = new FileStream
                    (Path.Combine(saveFolderPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                ImagesList.Add(new ProductImage
                {
                    ProductId = id,
                    ImageURL = Path.Combine(saveFolderPath, fileName)
                });

            }
            // Save images to the database
            _unitUnitOfWork.ProductImageRepo.AddRange(ImagesList);
            _unitUnitOfWork.Save();

        }

        private void DeleteProductImages(int id)
        {
            // Delete from folder
            List<ProductImage> imagesToBeDeleted = _unitUnitOfWork.ProductImageRepo
                .Where(x => x.ProductId == id).ToList();
            if (!imagesToBeDeleted.IsNullOrEmpty())
            {
                string imagePath = "";
                foreach (var image in imagesToBeDeleted)
                {
                    imagePath = image.ImageURL;
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
            }
            
            // Delete from database
            _unitUnitOfWork.ProductImageRepo.RemoveRange(imagesToBeDeleted);
            _unitUnitOfWork.Save();

        }


        #region APICALLS

        public IActionResult GetAll()
        {
            IEnumerable<Product> Products = _unitUnitOfWork.ProductRepo.GetAll();
            return Json(new { data = Products });
        }

        public IActionResult Delete(int id)
        {
            if (string.Equals(id.ToString(), null) || id == 0)
            {
                return Json(new { success = false, message = "Error happened, Please try again." });
            }


            // Delete product from db
            _unitUnitOfWork.ProductRepo.Remove(id);

            // Remove its images
            DeleteProductImages(id);

            return Json(new {success = true, message = "Product Deleted successfully"});
        }
        #endregion
    }
}
