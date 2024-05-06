using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StyleHub.Models;
using StyleHub.Models.ViewModel;

namespace StyleHub.Utility
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<AppUser, UserVM>();
        }
    }
}
