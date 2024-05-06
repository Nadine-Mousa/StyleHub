using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace StyleHub.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }     // Foreign Key
        [ValidateNever]
        public Category Category { get; set; }  // Navigation Property
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int? Rate { get; set; }
        [Required]
        public int Stock { get; set;}
        [ValidateNever]
        public List<ProductImage>? ProductImages { get; set; }

    }
}
