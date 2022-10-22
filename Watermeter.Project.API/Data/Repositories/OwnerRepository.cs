using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Watermeter.Project.API.Data.Context;
using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models;

namespace Watermeter.Project.API.Data.Repositories
{
    public class OwnerRepository: IOwnerRepository
    {
        private readonly MainContext context;
        public OwnerRepository(MainContext context)
        {
            this.context = context;
        }

        public async Task Save(Owner owner)
        {
            try
            {
                await context.AddAsync(owner);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Owner> GetSingle(int id)
        {
            try
            {
                var owner = await context.Owners.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();

                if(owner == null)
                    throw new NullReferenceException();

                return owner;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                context.Owners.Remove(await GetSingle(id));
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Update(Owner model)
        {
            try
            {
                context.Owners.Update(model);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
