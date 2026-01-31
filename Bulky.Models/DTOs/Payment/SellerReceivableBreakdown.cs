using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.Models.DTOs.Payment
{
    public sealed class SellerReceivableBreakdown
    {
        public Amount gross_amount { get; set; }
        public PaypalFee paypal_fee { get; set; }
        public Amount net_amount { get; set; }
    }
}
