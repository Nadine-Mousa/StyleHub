using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StyleHub.DataAccess.Repository.IRepository;
using StyleHub.Models;
using StyleHub.Models.ViewModel;

namespace StyleHubWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CheckoutController : Controller
    {
        private readonly PayPalClient _payPalClient;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        public CheckoutController(PayPalClient payPalClient, IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _payPalClient = payPalClient;
            _unitOfWork = unitOfWork;
            _userManager = userManager;

        }
        [ValidateAntiForgeryToken]
        public IActionResult Index(List<int> cartItemId)
        {
            var CarWithItems = new CartWithItemsVM()
            {
                Cart = _unitOfWork.CartRepo.Where(c => c.UserId == _userManager.GetUserId(User)).FirstOrDefault(),
                CartItems = _unitOfWork.CartItemRepo.Where(ci => cartItemId.Contains(ci.Id)).ToList(),

            };

            return View(CarWithItems);
        }
        [HttpPost]
        public async Task<IActionResult> Order(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "10.00";
                var currency = "EUR";

                // "reference" is the transaction key
                var reference = GetRandomInvoiceNumber();// "INV002";

                var response = await _payPalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _payPalClient.CaptureOrder(orderId);

                var reference = response.purchase_units[0].reference_id;

                // Put your logic to save the transaction here
                // You can use the "reference" variable as a transaction key

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
        public static string GetRandomInvoiceNumber()
        {
            return new Random().Next(999999).ToString();
        }
        public IActionResult Success()
        {
            return View();
        }

    }
}
