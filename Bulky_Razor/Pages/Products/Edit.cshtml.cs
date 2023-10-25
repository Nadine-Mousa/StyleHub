using Bulky_Razor.Data;
using Bulky_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor.Pages.Products
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Product Product { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int Id)
        {
            Product = _db.products.Find(Id);
        }

        public IActionResult OnPost(int Id)
        {
            if(Id.ToString() != null && Id != 0)
            {
                _db.products.Update(Product);
                _db.SaveChanges();
                TempData["success"] = "Book edited successfully!";
            }
            else
            {
                TempData["error"] = "Error happened while editing the book. Please, Try again";
            }
            
            return RedirectToPage("Index");
        }
    }
}
