using AutoMapper;
using Watermeter.Project.API.Data.Repositories.Interfaces;
using Watermeter.Project.API.Models;
using Watermeter.Project.API.Services.Interfaces;

namespace Watermeter.Project.API.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository repository;
        private readonly IMapper msvc;
        public OwnerService(IOwnerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.msvc = mapper;
        }

        public async Task SaveModel(OwnerModel model)
        {
            try
            {
                var owner = msvc.Map<Owner>(model);
                await repository.Save(owner);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Owner> GetOwner(int id)
        {
            try
            {
                return await repository.GetSingle(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Owner>> GetOwnersList()
        {
            try
            {
                return await repository.GetList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<OwnerModel> GetOwnerModel(int id)
        {
            try
            {
                var owner = await repository.GetSingle(id);
                var model = msvc.Map<OwnerModel>(owner);
                return model;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteOwner(int id)
        {
            try
            {
                return await repository.Delete(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateOwner(int id, OwnerModel model)
        {
            try
            {
                var owner = await repository.GetSingle(id);
                var newOwner = msvc.Map<Owner>(model);
                newOwner.IdOwner = owner.IdOwner;
                await repository.Update(newOwner);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> ValidateCredentialsAsync(Credentials credentials, string system)
        {
            try
            {
                if (system.Equals("FrontEndConsole"))
                    return await repository.ValidateCredentials(credentials);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
