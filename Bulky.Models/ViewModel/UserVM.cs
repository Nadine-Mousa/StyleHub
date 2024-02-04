using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNook.Models.ViewModel
{
    public  class UserVM
    {

        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public IEnumerable<string> Roles {  get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber {  get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }
        [Display(Name = "Profile Picture")]
        public byte[] ProfilePicture {  get; set; }
        

    }
}
