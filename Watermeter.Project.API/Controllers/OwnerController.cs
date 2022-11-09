using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Watermeter.Project.API.Data.Repositories;
using Watermeter.Project.API.Models;
using Watermeter.Project.API.Services.Interfaces;

namespace Watermeter.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]OwnerModel model)
        {
            try
            {
                await ownerService.SaveModel(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpGet("GetOwner")]
        public async Task<IActionResult> GetOwner(int id)
        {
            try
            {
                return Ok(await ownerService.GetOwner(id));
            }
            catch (NullReferenceException e)
            {
                return NotFound("Usuário não encontrado");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpGet("GetOwnersList")]
        public async Task<IActionResult> GetOwnersAsync()
        {
            try
            {
                return Ok(await ownerService.GetOwnersList());
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpGet("GetOwnerModel")]
        public async Task<IActionResult> GetOwnerModel([FromQuery]int id)
        {
            try
            {
                return Ok(await ownerService.GetOwnerModel(id));
            }
            catch (NullReferenceException e)
            {
                return NotFound("Usuário não encontrado");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpDelete("DeleteOwner")]
        public async Task<IActionResult> DeleteOwner([FromQuery]int id)
        {
            try
            {
                if (await ownerService.DeleteOwner(id))
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
        [HttpPatch("UpdateOwner")]
        public async Task<IActionResult> UpdateOwner([FromQuery] int id, [FromBody] OwnerModel model)
        {
            try
            {
                if (await ownerService.UpdateOwner(id, model))
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
