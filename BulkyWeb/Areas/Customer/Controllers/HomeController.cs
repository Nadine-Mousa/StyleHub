using BookNook.DataAccess.Repository.IRepository;
using BookNook.Models;
using BookNook.Models.ViewModel;
using BookNook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookNookWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            string properties = "Category,ProductImages";
            homeVM.womenProducts = _unitOfWork.ProductRepo.Where(p => p.Category.Name == "Women", properties);
            homeVM.menProducts = _unitOfWork.ProductRepo.Where(p => p.Category.Name == "Men", properties);
            homeVM.kidsProducts = _unitOfWork.ProductRepo.Where(p => p.Category.Name == "kids", properties);
            homeVM.accessoriesProducts = _unitOfWork.ProductRepo.Where(p => p.Category.Name == "Accessories", properties);


            return View(homeVM);
        }
        public IActionResult Details(int id)
        {
            Product productFromDb = _unitOfWork.ProductRepo.Get(p => p.Id == id, includeProperties: "Category,ProductImages");
            
            return View(productFromDb);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Products(int? Id)
        {
            List<Product> products = new List<Product>();
            if(Id == null)
            {
                products = _unitOfWork.ProductRepo.GetAll(includeProperties: "ProductImages").ToList();
                products = Helper.ShuffleList<Product>(products);
            }
            else
            {
                products = _unitOfWork.ProductRepo.Where(p => p.CategoryId == Id, includeProperties:"ProductImages").ToList();
            }
            
            return View(products);
        }

        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
