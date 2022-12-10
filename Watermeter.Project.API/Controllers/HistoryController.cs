using Microsoft.AspNetCore.Mvc;
using Watermeter.Project.API.Services.Interfaces;

namespace Watermeter.Project.API.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryService service;

        public HistoryController(IHistoryService service)
        {
            this.service = service;
        }

        [HttpGet("GetHistoriesById")]
        public async Task<IActionResult> GetHistories([FromQuery]int idOwner)
        {
            try
            {
                return Ok(await service.GetHistoriesAsync(idOwner));
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
        [HttpGet("GetCalculationsById")]
        public async Task<IActionResult> GetCalculations([FromQuery]int idOwner)
        {
            try
            {
                return Ok(await service.GetCalculationsAsync(idOwner));
            }
            catch(Exception e)
            {
                return BadRequest($"Erro: {e.Message} + Stacktrace: {e.StackTrace}");
            }
        }
    }
}
