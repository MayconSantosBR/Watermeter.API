using Watermeter.Project.API.Models;

namespace Watermeter.Project.API.Services.Interfaces
{
    public interface IArduinoService
    {
        void PostMeasure(ArduinoModel model);
    }
}
