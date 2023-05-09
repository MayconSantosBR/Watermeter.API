using Watermeter.Project.API.Entities;

namespace Watermeter.Project.API.Data.Repositories.Interfaces
{
    public interface IArduinoRepository
    {
        Task Save(Arduino arduino, Owner owner);
        Task<Arduino> GetArduino(int id);
        Task<List<Arduino>> GetArduinos();
        Task<List<Arduino>> GetArduinosById(int idOwner);
        Task<bool> Delete(int id);
        Task<bool> Update(Arduino model);
    }
}