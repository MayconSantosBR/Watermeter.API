using System.Net;
using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models.User;

namespace Watermeter.Project.API.Data.Repositories.Interfaces
{
    public interface IOwnerRepository
    {
        Task Save(Owner owner);
        Task<Owner> GetSingle(int id);
        Task<List<Owner>> GetList();
        Task<bool> Delete(int id);
        Task<bool> Update(Owner model);
        Task<int> ValidateCredentials(Credentials credentials);
    }
}
