using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNook.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        public string? HomeAddress {  get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }

    }
}
