using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models.Arduino;

namespace Watermeter.Project.API.Services.Interfaces
{
    public interface IArduinoService
    {
        Task CreateArduino(ArduinoCreateModel model);
        Task<Arduino> GetArduinoAsync(int id);
        Task<List<Arduino>> GetArduinosListAsync();
        Task<ArduinoNameUpdateModel> GetUpdateModelAsync(int id);
        Task<bool> DeleteArduino(int id);
        Task<bool> UpdateArduino(int id, ArduinoNameUpdateModel model);
        Task<List<Arduino>> GetArduinosListByIdAsync(int idOwner);
    }
}
