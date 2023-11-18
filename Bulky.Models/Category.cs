using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookNook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The Category Name should not exceed 30 characters")]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "The Display Order should be between 1 and 100")]
        public int DisplayOrder { get; set; }
        [ValidateNever]
        public IEnumerable<Product> Products { get; set; }
        [DisplayName("Category Image")]
        public string? ImageUrl { get; set; }

    }
}
