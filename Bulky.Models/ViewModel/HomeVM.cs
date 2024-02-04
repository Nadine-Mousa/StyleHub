using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNook.Models.ViewModel
{
    public  class HomeVM
    {
        public IEnumerable<Product> womenProducts { get; set; }
        public IEnumerable<Product> menProducts { get; set; }
        public IEnumerable<Product> kidsProducts { get; set; }
        public IEnumerable<Product> accessoriesProducts { get; set; }

    }
}
