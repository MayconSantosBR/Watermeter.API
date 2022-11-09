using AutoMapper;

namespace Watermeter.Project.API.Models.Profiles
{
    public class ArduinoProfile: Profile
    {
        public ArduinoProfile()
        {
            CreateMap<ArduinoCreateModel, Arduino>();
            CreateMap<Arduino, ArduinoCreateModel>();
            CreateMap<Arduino, Arduino>()
                .ForMember(src => src.IdArduino, c => c.Ignore());
            CreateMap<ArduinoNameUpdateModel, Arduino>();
        }
    }
}
