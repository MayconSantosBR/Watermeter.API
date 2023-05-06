using AutoMapper;
using Watermeter.Project.API.Models.Profiles;

namespace Watermeter.Project.API.Models
{
    public class MapperService
    {
        public MapperService()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OwnerProfile>();
                cfg.AddProfile<ArduinoProfile>();
                cfg.AddProfile<UserProfile>();
            });

            configuration.CreateMapper();
        }
    }
}
