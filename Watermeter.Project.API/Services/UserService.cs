using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models;
using Watermeter.Project.API.Services.Interfaces;

namespace Watermeter.Project.API.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper msvc;
        private readonly UserManager<IdentityUser<int>> userManager;
        private readonly SignInManager<IdentityUser<int>> signInManager;

        public UserService(IMapper msvc, UserManager<IdentityUser<int>> manager, SignInManager<IdentityUser<int>> signInManager)
        {
            this.msvc = msvc;
            this.userManager = manager;
            this.signInManager = signInManager;
        }

        public async Task<Result> CreateUserAsync(OwnerModel model)
        {
            try
            {
                User user = msvc.Map<User>(model);
                IdentityUser<int> identityUser = msvc.Map<IdentityUser<int>>(user);

                var result = await userManager.CreateAsync(identityUser, user.Password);
                if (!result.Succeeded)
                {
                    return ErrorTreatment(result);
                }
                else
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                    return Result.Ok().WithSuccess(code);
                }
            }
            catch
            {
                throw;
            }
        }

        private static Result ErrorTreatment(IdentityResult result)
        {
            var message = "";

            foreach (var error in result.Errors)
                message = $"[ERROR] Code: {error.Code}. Message: {error.Description}.\n";

            return Result.Fail(message);
        }

        public async Task<Result> ConfirmEmailAsync(ConfirmEmailBody confirm)
        {
            try
            {
                var user = userManager.Users.FirstOrDefault(c => c.Id.Equals(confirm.UserId));

                if (user == null)
                    return Result.Fail("Failed to find your user in the database");

                var result = await userManager.ConfirmEmailAsync(user, confirm.ActivationCode);

                if (!result.Succeeded)
                    return ErrorTreatment(result);
                else
                    return Result.Ok();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Result> LoginAsync(LoginBody login)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);
                if (!result.Succeeded)
                {
                    return Result.Fail("Login failed, please check the required factors to login.");
                }
                else
                {
                    var user = signInManager.UserManager.Users
                        .FirstOrDefault(c => c.NormalizedUserName.Equals(login.Username.ToUpper()));

                    if (user == null)
                        return Result.Fail("Failed to find your user in the database");

                    var token = await CreateTokenAsync(user);

                    return Result.Ok().WithSuccess(token.Value);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Result> LogoutAsync()
        {
            try
            {
                await signInManager.SignOutAsync();
                return Result.Ok();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Token> CreateTokenAsync(IdentityUser<int> user)
        {
            try
            {
                Claim[] userRights = new Claim[]
                {
                    new Claim("username", user.UserName),
                    new Claim("id", user.Id.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn"));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: userRights, 
                    signingCredentials: credentials, 
                    expires: DateTime.UtcNow.AddHours(-3).AddHours(1)
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return new Token(tokenString);
            }
            catch
            {
                throw;
            }
        }
    }
}
