using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.Models.DTOs.Payment
{
    public sealed class PurchaseUnit
    {
        
        public Amount amount { get; set; }
        public string reference_id { get; set; }
        public Shipping shipping { get; set; }
        public Payments payments { get; set; }
        
    }
}
