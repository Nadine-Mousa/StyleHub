using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNook.Models.ViewModel
{
    public class CartWithItemsVM
    {
        public Cart Cart { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
