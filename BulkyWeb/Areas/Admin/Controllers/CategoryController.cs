using StyleHub.DataAccess;
using StyleHub.DataAccess.Repository;
using StyleHub.DataAccess.Repository.IRepository;
using StyleHub.Models;
using StyleHub.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;

namespace StyleHubWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.CategoryRepo.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category, IFormFile? file)
        {

            // Custom Validations
            if (string.Equals(category.Name, category.DisplayOrder))
            {
                ModelState.AddModelError("Name", "The Name and Display Order cannot be exactly the same");
            }
            if (!string.Equals(category.Name, null) && string.Equals(category.Name, "categoryName"))
            {
                ModelState.AddModelError("", "Name is not a valid value for a Category");
            }

            if(file != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string saveFolderPath = Path.Combine(wwwRootPath, @"images/categories");
                using (var fileStream = new FileStream(Path.Combine(saveFolderPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                category.ImageUrl = @"/images/categories/" + fileName ;
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepo.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category added successfully";
                return RedirectToAction("Index");
            }
            return View();


        }

        public IActionResult Edit(int id)
        {
            if (id.ToString() == null || id == 0)
            {
                return NotFound();
            }

            Category category = _unitOfWork.CategoryRepo.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category, IFormFile? file)
        {
            // Custom Validations
            if (string.Equals(category.Name, category.DisplayOrder))
            {
                ModelState.AddModelError("Name", "The Name and Display Order cannot be exactly the same");
            }
            if (!string.Equals(category.Name, null) && string.Equals(category.Name, "categoryName"))
            {
                ModelState.AddModelError("", "Name is not a valid value for a Category");
            }
            // Category Image
            if(file != null)
            {
                // Delete the old image if exists
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (!category.ImageUrl.IsNullOrEmpty())
                {
                    string oldImagePath = Path.Combine(wwwRootPath, category.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Add new image
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string saveFolderPath = Path.Combine(wwwRootPath, @"images/categories");
                using (var fileStream = new FileStream(Path.Combine(saveFolderPath,fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                category.ImageUrl = @"/images/categories/" + fileName;
            }

            // Update Category
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepo.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }


        //public IActionResult Delete(int id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    Category? category = _unitOfWork.CategoryRepo.Get(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Category? category = _unitOfWork.CategoryRepo.Get(id);
        //    if (category != null)
        //    {
        //        _unitOfWork.CategoryRepo.Remove(category);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Category deleted successfully";
        //    }
        //    return RedirectToAction("Index");
        //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> Categories = _unitOfWork.CategoryRepo.GetAll().ToList();
            return Json(new {data  = Categories});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            if(id.ToString() == null || id == 0)
            {
                return Json(new {success = false, message = "Error happened while deleting the category!"});
            }



            Category objectToBeDeleted = _unitOfWork.CategoryRepo.Get(o => o.Id == id);
            string imagePath = _webHostEnvironment.WebRootPath + objectToBeDeleted.ImageUrl;
            if (imagePath != null && System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _unitOfWork.CategoryRepo.Remove(id);
            _unitOfWork.Save();

            return Json(new { success = true, message= "Category Deleted successfully!" });
        }


        #endregion


    }
}
