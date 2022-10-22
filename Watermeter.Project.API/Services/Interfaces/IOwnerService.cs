using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models;

namespace Watermeter.Project.API.Services.Interfaces
{
    public interface IOwnerService
    {
        Task SaveModel(OwnerModel model);
        Task<Owner> GetOwner(int id);
        Task<OwnerModel> GetOwnerModel(int id);
        Task<bool> DeleteOwner(int id);
        Task<bool> UpdateOwner(int id, OwnerModel model);
    }
}