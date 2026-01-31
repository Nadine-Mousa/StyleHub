using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.Models.DTOs.Payment
{
    public sealed class Payer
    {
        public Name name { get; set; }
        public string email_address { get; set; }
        public string payer_id { get; set; }
    }
}
