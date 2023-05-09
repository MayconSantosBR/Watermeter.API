using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models.User;

namespace Watermeter.Project.API.Models.Profiles
{
    public class OwnerProfile: Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerModel>();
            CreateMap<OwnerModel, Owner>();
            CreateMap<Owner, Owner>()
                .ForMember(src => src.IdOwner, c => c.Ignore());
        }
    }
}
