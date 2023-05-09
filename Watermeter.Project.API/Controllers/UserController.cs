using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models.User;
using Watermeter.Project.API.Models.User.Create;
using Watermeter.Project.API.Models.User.Login;
using Watermeter.Project.API.Services.Interfaces;

namespace Watermeter.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IOwnerService ownerService;
        public UserController(IUserService service, IOwnerService ownerService)
        {
            this.userService = service;
            this.ownerService = ownerService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]OwnerModel model)
        {
            try
            {
                var result = await userService.CreateUserAsync(model);
                if (result.IsSuccess)
                {
                    await ownerService.SaveModel(model);
                    return Ok(JsonConvert.SerializeObject(result.Successes));
                }
                else
                {
                    return BadRequest(JsonConvert.SerializeObject(result.Errors));
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("email/confirm")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]ConfirmEmailBody body)
        {
            try
            {
                var result = await userService.ConfirmEmailAsync(body);
                if (result.IsSuccess)
                    return Ok("Success!");
                else
                    return BadRequest(JsonConvert.SerializeObject(result.Errors));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginBody model)
        {
            try
            {
                var result = await userService.LoginAsync(model);

                if (result.IsSuccess)
                    return Ok(JsonConvert.SerializeObject(result.Successes));
                else
                    return Unauthorized(JsonConvert.SerializeObject(result.Errors));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var result = await userService.LogoutAsync();
                return Ok("Success!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
