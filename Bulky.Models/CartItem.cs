using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleHub.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [Required] 
        public int ProductId { get; set; }
        [ValidateNever]
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        [ValidateNever]
        public Cart? Cart { get; set; }
    }
}
