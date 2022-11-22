
using Microsoft.EntityFrameworkCore;
using Watermeter.Project.API.Data.Contexts;
using Watermeter.Project.API.Data.Repositories.Interfaces;

namespace Watermeter.Project.API.Data.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly MainContext context;
        public HistoryRepository(MainContext context)
        {
            this.context = context;
        }

        public async Task Save(History model)
        {
            try
            {
                context.Histories.Add(model);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<History>> GetHistories(int idOwner)
        {
            try
            {
                return await context.Histories.Where(c => c.IdOwner == idOwner).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteAll(int idOwner)
        {
            try
            {
                var achieviments = await context.Achieviments.AsNoTracking().Where(c => c.IdOwner == idOwner).ToListAsync();
                context.Achieviments.RemoveRange(achieviments);
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
