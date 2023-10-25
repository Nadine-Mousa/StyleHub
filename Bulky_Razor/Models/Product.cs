using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bulky_Razor.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Book Title")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }


    }
}
