using Microsoft.AspNetCore.Mvc;
using Watermeter.Project.API.Models;
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

        [HttpPost("PostMeasure")]
        public IActionResult PostWaterMeasure([FromBody]ArduinoModel model)
        {
            try
            {
                service.PostMeasure(model);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        public IActionResult Ping()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest("Not pong :(");
            }
        }
    }
}
