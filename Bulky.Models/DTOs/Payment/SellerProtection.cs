using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.Models.DTOs.Payment
{
    public sealed class SellerProtection
    {
        public string status { get; set; }
        public List<string> dispute_categories { get; set; }
    }
}
