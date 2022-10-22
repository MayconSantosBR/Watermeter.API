using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models;
using Watermeter.Project.API.Services.Interfaces;

namespace Watermeter.Project.API.Services
{
    public class ArduinoService: IArduinoService
    {
        public void PostMeasure(ArduinoModel model)
        {
            Arduino arduino = new()
            {
                Id = model.Id,
                LastMeasure = DateTime.Now.Date
            };

            Console.WriteLine(arduino.LastMeasure);
        }
    }
}
