using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.Models.DTOs.Payment
{
    public sealed class CreateOrderRequest
    {
        public string intent { get; set; }
        public List<PurchaseUnit> purchase_units { get; set; } = new();

    }
}
