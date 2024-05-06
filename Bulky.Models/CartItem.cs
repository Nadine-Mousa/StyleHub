using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNook.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [Required] 
        public int ProductId { get; set; }
        [ValidateNever]
        public Product Product { get; set; }
        public int Quantity { get; set; } = 0;
        public double TotalPrice { get; set; }
    }
}
