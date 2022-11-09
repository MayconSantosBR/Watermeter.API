using AutoMapper;
using Microsoft.Win32.SafeHandles;
using Watermeter.Project.API.Data.Repositories.Interfaces;
using Watermeter.Project.API.Models;
using Watermeter.Project.API.Services.Interfaces;

namespace Watermeter.Project.API.Services
{
    public class ArduinoService: IArduinoService
    {
        private readonly IArduinoRepository arduinoRepository;
        private readonly IOwnerRepository ownerRepository;
        private readonly IMapper msvc;
        public ArduinoService(IArduinoRepository arduinoRepository, IOwnerRepository ownerRepository, IMapper mapper)
        {
            this.arduinoRepository = arduinoRepository;
            this.ownerRepository = ownerRepository;
            this.msvc = mapper;
        }
        public async Task CreateArduino(ArduinoCreateModel model)
        {
            try
            {
                var arduino = msvc.Map<Arduino>(model);
                var owner = await ownerRepository.GetSingle(arduino.IdOwner);
                await arduinoRepository.Save(arduino, owner);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Arduino> GetArduinoAsync(int id)
        {
            try
            {
                return await arduinoRepository.GetArduino(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Arduino>> GetArduinosListAsync()
        {
            try
            {
                return await arduinoRepository.GetArduinos();
            }
            catch
            {
                throw;
            }
        }
        public async Task<ArduinoNameUpdateModel> GetUpdateModelAsync(int id)
        {
            try
            {
                var arduino = await arduinoRepository.GetArduino(id);
                var model = msvc.Map<ArduinoNameUpdateModel>(arduino);
                return model;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteArduino(int id)
        {
            try
            {
                return await arduinoRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateArduino(int id, ArduinoNameUpdateModel model)
        {
            try
            {
                var arduino = await arduinoRepository.GetArduino(id);
                var newArduino = msvc.Map<Arduino>(model);
                newArduino.IdArduino = arduino.IdArduino;
                newArduino.IdOwner = arduino.IdOwner;
                await arduinoRepository.Update(newArduino);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
