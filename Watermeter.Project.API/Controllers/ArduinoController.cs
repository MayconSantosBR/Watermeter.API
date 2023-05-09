using Microsoft.AspNetCore.Mvc;
using Watermeter.Project.API.Models.Arduino;
using Watermeter.Project.API.Services;
using Watermeter.Project.API.Services.Interfaces;

namespace Watermeter.Project.API.Controllers
{
    public class ArduinoController : Controller
    {
        private readonly IArduinoService service;
        public ArduinoController(IArduinoService service)
        {
            this.service = service;
        }

        [HttpPost("CreateArduino")]
        public async Task<IActionResult> CreateArduino([FromBody]ArduinoCreateModel model)
        {
            try
            {
                await service.CreateArduino(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpGet("GetArduino")]
        public async Task<IActionResult> GetArduino([FromQuery]int id)
        {
            try
            {
                return Ok(await service.GetArduinoAsync(id));
            }
            catch (NullReferenceException)
            {
                return NotFound("Arduino não encontrado");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpGet("GetArduinoList")]
        public async Task<IActionResult> GetArduinoList()
        {
            try
            {
                return Ok(await service.GetArduinosListAsync());
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpGet("GetArduinoListById")]
        public async Task<IActionResult> GetArduinoListById([FromQuery]int idOwner)
        {
            try
            {
                return Ok(await service.GetArduinosListByIdAsync(idOwner));
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpGet("GetArduinoUpdateModel")]
        public async Task<IActionResult> GetArduinoUpdateModel([FromQuery] int id)
        {
            try
            {
                return Ok(await service.GetUpdateModelAsync(id));
            }
            catch (NullReferenceException)
            {
                return NotFound("Arduino não encontrado");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpDelete("DeleteArduino")]
        public async Task<IActionResult> DeleteArduino([FromQuery] int id)
        {
            try
            {
                if (await service.DeleteArduino(id))
                    return Ok();
                else
                    return BadRequest("Houve algum erro para deletar");
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpPatch("UpdateArduino")]
        public async Task<IActionResult> UpdateArduinoName([FromQuery] int id, [FromBody] ArduinoNameUpdateModel model)
        {
            try
            {
                if (await service.UpdateArduino(id, model))
                    return Ok();
                else
                    return BadRequest("Houve algum erro para atualizar");
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
    }
}
