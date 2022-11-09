using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;

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
