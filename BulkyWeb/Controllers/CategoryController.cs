using BookNook.DataAccess;
using BookNook.DataAccess.Repository;
using BookNook.DataAccess.Repository.IRepository;
using BookNook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookNookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IRepositoryCategory _repo;

        public CategoryController(IRepositoryCategory repo, ApplicationDbContext db)
        {
            _db = db;
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Category>  categories = _repo.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            // Custom Validations
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Name and Display Order cannot be exactly the same");
            }
            if(category.Name != null && category.Name.ToLower() == "name")
            {
                ModelState.AddModelError("", "Name is not a valid value for a Category");
            }

            if(ModelState.IsValid)
            {
                _repo.Add(category);
                TempData["success"] = "Category added successfully";
                return RedirectToAction("Index");
            }
            return View();


        }
        
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _repo.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            // Custom Validations
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Name and Display Order cannot be exactly the same");
            }
            if (category.Name != null && category.Name.ToLower() == "name")
            {
                ModelState.AddModelError("", "Name is not a valid value for a Category");
            }

            if(ModelState.IsValid)
            {
                _repo.Update(category);
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _repo.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _repo.Get(id);
            if (category != null)
            {
                _repo.Remove(category);
                TempData["success"] = "Category deleted successfully";
            }
                return RedirectToAction("Index");
        }



    }
}
