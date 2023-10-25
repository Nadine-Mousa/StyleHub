using Bulky_Razor.Data;
using Bulky_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Product> ProductsList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            ProductsList = _db.products.ToList();

        }
    }
}
