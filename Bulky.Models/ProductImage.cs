using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNook.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public int ProductId { get; set; }
        [ValidateNever]
        public Product Product { get; set; }
    }
}
