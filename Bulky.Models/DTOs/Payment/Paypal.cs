using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.Models.DTOs.Payment
{
    public sealed class Paypal
    {
        public Name name { get; set; }
        public string email_address { get; set; }
        public string account_id { get; set; }
    }
}
