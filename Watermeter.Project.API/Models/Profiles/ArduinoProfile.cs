using AutoMapper;
using Watermeter.Project.API.Models.Arduino;

namespace Watermeter.Project.API.Models.Profiles
{
    public class ArduinoProfile: Profile
    {
        public ArduinoProfile()
        {
            CreateMap<ArduinoCreateModel, Entities.Arduino>();
            CreateMap<Entities.Arduino, ArduinoCreateModel>();
            CreateMap<Entities.Arduino, Entities.Arduino>()
                .ForMember(src => src.IdArduino, c => c.Ignore());
            CreateMap<ArduinoNameUpdateModel, Entities.Arduino>();
        }
    }
}
