using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StyleHub.Models.DTOs.Payment
{
    public sealed class Payments
    {
        public List<Capture> captures { get; set; }
    }
}
