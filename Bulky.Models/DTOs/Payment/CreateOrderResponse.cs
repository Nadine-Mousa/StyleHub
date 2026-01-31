using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.Models.DTOs.Payment
{
    public class CreateOrderResponse
    {
        public string id { get; set; }
        public string status { get; set; }
        public List<Link> links { get; set; }
    }
}
