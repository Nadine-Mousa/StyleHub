using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StyleHub.DataAccess.Repository.IRepository;
using StyleHub.Models;
using StyleHub.Utility;
using System.Security.Claims;


namespace StyleHubWeb.Areas.Customer.Controllers
{
    [Area(SD.Customer_Area)]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public CartController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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

            var product = _unitOfWork.ProductRepo.Get(p => p.Id == productId);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found" });
            }

            var total = product.Price * quantity;



            // Find cart of the user
            string userId = _userManager.GetUserId(User);
            var cart = _unitOfWork.CartRepo.Get(c => c.UserId.ToString() == userId, "CartItems");
            if(cart == null)
            {
                // Create new cart for user
                cart = new Cart
                {
                    UserId = userId,
                    TotalPrice = 0,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                _unitOfWork.CartRepo.Add(cart);
                _unitOfWork.Save();
            }

            // if the product exists in cart, update quantity and total price
            var existingCartItem = cart.CartItems?.FirstOrDefault(ci => ci.ProductId == productId);
            if (existingCartItem == null)
            {
                // create new cart item
                var CartItme = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    TotalPrice = total,
                    CartId = cart.Id
                };
                _unitOfWork.CartItemRepo.Add(CartItme);

            }
            else
            {
                // update existing cart item
                existingCartItem.Quantity = quantity;
                existingCartItem.TotalPrice = total;
            }
            // update cart total price
            cart.TotalPrice = cart.CartItems?.Sum(ci => ci.TotalPrice) ?? 0;
            _unitOfWork.Save();




            return Json(new
                {
                    success = true,
                    message = "Product added to cart sucessfully!",
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
