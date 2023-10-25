using Bulky_Razor.Data;
using Bulky_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bulky_Razor.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.products.Add(Product);
                _db.SaveChanges();
                TempData["success"] = "Book added successfully!";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["error"] = "Error happened while adding the book. Please, Try again.";
            }
            return RedirectToPage("Create");

        }
    }
}
