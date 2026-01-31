using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.Models.DTOs.Payment
{
    public sealed class Link
    {
        public string? href { get; set; }
        public string? rel { get; set; }
        public string? method { get; set; }
    }
}
