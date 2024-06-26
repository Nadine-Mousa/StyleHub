﻿using AutoMapper;
using StyleHub.Models;
using StyleHub.Models.ViewModel;
using StyleHub.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StyleHubWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private IMapper _mapper;
        public UserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var mappedUsers = _mapper.Map<List<UserVM>>(users);
            
            //var users = await _userManager.Users.Select(user => new UserVM
            //{
            //    Id = user.Id,
            //    UserName = user.UserName,
            //    Email = user.Email,
            //    EmailConfirmed = user.EmailConfirmed,
            //    //Roles = _userManager.GetRolesAsync(user).Result,
            //    PhoneNumber = user.PhoneNumber,
            //    Country = user.Country,
            //    City = user.City,
            //    HomeAddress = user.HomeAddress,
            //    ProfilePicture = user.ProfilePicture

            //}).ToListAsync();



           
            return View(mappedUsers);
        }
    }
}
