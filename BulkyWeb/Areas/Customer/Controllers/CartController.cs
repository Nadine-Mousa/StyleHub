using StyleHub.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StyleHub.DataAccess.Repository.IRepository;
using StyleHub.Models;


namespace StyleHubWeb.Areas.Customer.Controllers
{
    [Area(SD.Customer_Area)]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }   

        // GET: CartController
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // legacy GET stub kept for compatibility
        public ActionResult AddToCart(int id)
        {
            // placeholder for GET route if needed by older code
            return View("Index");
        }

        // POST: CartController/AddToCart
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddToCart(int productId, int quantity)
        {
            if (quantity <1) quantity =1;

            var product = _unitOfWork.ProductRepo.Get(p => p.Id == productId, includeProperties: "ProductImages");
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found" });
            }

            var total = product.Price * quantity;

            // NOTE: persistence (session / DB) is intentionally omitted for now.
            // This endpoint returns the computed data so the client can proceed with UI updates.

            return Json(new
            {
                success = true,
                message = "Product added to cart (client-side).",
                data = new
                {
                    productId = productId,
                    productName = product.Name,
                    unitPrice = product.Price,
                    quantity = quantity,
                    totalPrice = total
                }
            });
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Update(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
