using Bulky_Razor.Data;
using Bulky_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor.Pages.Products
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        ApplicationDbContext _db;
        public Product Product { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int Id)
        {
            Product = _db.products.Find(Id);
        }
        public IActionResult OnPost()
        {
            Product? product = _db.products.Find(Product.Id);
            if(product != null)
            {
                _db.products.Remove(product);
                _db.SaveChanges();
                TempData["success"] = "Book deleted successfully!";

            }
            else
            {
                TempData["error"] = "Error happened while deleting the book. Please, Try again";

            }

            return RedirectToPage("Index");
        }
    }
}
