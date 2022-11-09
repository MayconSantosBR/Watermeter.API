using Microsoft.EntityFrameworkCore;
using Watermeter.Project.API.Data.Contexts;
using Watermeter.Project.API.Data.Repositories.Interfaces;

namespace Watermeter.Project.API.Data.Repositories
{
    public class ArduinoRepository: IArduinoRepository
    {
        private readonly MainContext context;
        public ArduinoRepository(MainContext context)
        {
            this.context = context;
        }

        public async Task Save(Arduino arduino, Owner owner)
        {
            try
            {
                await context.AddAsync(arduino);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Arduino> GetArduino(int id)
        {
            try
            {
                var arduino = await context.Arduinos.AsNoTracking().FirstOrDefaultAsync(c => c.IdArduino == id);

                if (arduino == null)
                    throw new NullReferenceException();

                return arduino;
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
                context.Arduinos.Remove(await GetArduino(id));
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Update(Arduino model)
        {
            try
            {
                context.Arduinos.Update(model);
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
