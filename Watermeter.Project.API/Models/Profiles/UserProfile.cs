using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Watermeter.Project.API.Entities;

namespace Watermeter.Project.API.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<OwnerModel, User>()
                .ForMember(c => c.PhoneNumber, src => src.MapFrom(c => c.Cellphone))
                .ForMember(c => c.Username, src => src.MapFrom(c => c.Name + c.LastName));
            CreateMap<User, IdentityUser<int>>();
        }
    }
}
