using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.Models.DTOs.Payment
{
    public sealed class PaypalFee
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }
}
