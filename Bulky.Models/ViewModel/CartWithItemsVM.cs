using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleHub.Models.ViewModel
{
    public class CartWithItemsVM
    {
        public Cart Cart { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
