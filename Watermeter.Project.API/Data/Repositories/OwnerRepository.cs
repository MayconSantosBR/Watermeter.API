using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Watermeter.Project.API.Data.Contexts;
using Watermeter.Project.API.Data.Repositories.Interfaces;
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
                var owner = await context.Owners.AsNoTracking()
                    .Include(c => c.Arduinos)
                    .Include(c => c.Achieviments)
                    .Include(c => c.Histories)
                    .Where(c => c.IdOwner == id)
                    .FirstOrDefaultAsync();

                if(owner == null)
                    throw new NullReferenceException();

                return owner;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Owner>> GetList()
        {
            try
            {
                return await context.Owners.ToListAsync();
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
                List<Achieviment> achieviments = await context.Achieviments.Where(c => c.IdOwner == id).ToListAsync();
                List<Arduino> arduinos = await context.Arduinos.Where(c => c.IdOwner == id).ToListAsync();
                List<History> histories = await context.Histories.Where(c => c.IdOwner == id).ToListAsync();

                
                context.Achieviments.RemoveRange(achieviments);
                context.Histories.RemoveRange(histories);
                context.Arduinos.RemoveRange(arduinos);
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
