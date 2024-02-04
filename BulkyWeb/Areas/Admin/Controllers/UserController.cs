using BookNook.Models;
using BookNook.Models.ViewModel;
using BookNook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(user => new UserVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                //Roles = _userManager.GetRolesAsync(user).Result,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country,
                City = user.City,
                HomeAddress = user.HomeAddress,
                ProfilePicture = user.ProfilePicture

            }).ToListAsync();

           
            return View(users);
        }
    }
}
