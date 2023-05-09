using FluentResults;
using Microsoft.AspNetCore.Identity;
using Watermeter.Project.API.Models.User;
using Watermeter.Project.API.Models.User.Create;
using Watermeter.Project.API.Models.User.Login;

namespace Watermeter.Project.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result> CreateUserAsync(OwnerModel model);
        Task<Result> LoginAsync(LoginBody model);
        Task<Token> CreateTokenAsync(IdentityUser<int> user);
        Task<Result> LogoutAsync();
        Task<Result> ConfirmEmailAsync(ConfirmEmailBody confirm);
    }
}