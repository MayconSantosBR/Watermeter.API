using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using Watermeter.Project.API.Entities;

namespace Watermeter.Project.API.Models.Profiles
{
    public class OwnerProfile: Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerModel>();
            CreateMap<OwnerModel, Owner>();
            CreateMap<Owner, Owner>()
                .ForMember(src => src.Id, c => c.Ignore());
        }
    }
}
