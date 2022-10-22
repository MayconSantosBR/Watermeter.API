using Watermeter.Project.API.Entities;

namespace Watermeter.Project.API.Data.Repositories
{
    public interface IOwnerRepository
    {
        Task Save(Owner owner);
        Task<Owner> GetSingle(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(Owner model);
    }
}
