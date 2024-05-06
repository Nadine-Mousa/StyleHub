using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookNook.Models;
using BookNook.Models.ViewModel;

namespace BookNook.Utility
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<AppUser, UserVM>();
        }
    }
}
