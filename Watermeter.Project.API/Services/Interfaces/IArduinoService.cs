using Watermeter.Project.API.Models;

namespace Watermeter.Project.API.Services.Interfaces
{
    public interface IArduinoService
    {
        Task CreateArduino(ArduinoCreateModel model);
        Task<Arduino> GetArduinoAsync(int id);
        Task<ArduinoNameUpdateModel> GetUpdateModelAsync(int id);
        Task<bool> DeleteArduino(int id);
        Task<bool> UpdateArduino(int id, ArduinoNameUpdateModel model);
    }
}
