using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Paella.Infrastructure.Entities;

namespace Paella.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<PaellaUser> _userManager;

        public UserService(UserManager<PaellaUser> userManager)
        {
            _userManager = userManager;
        }

        public PaellaUser FindByName(string name)
        {
            return _userManager.FindByNameAsync(name)
                .GetAwaiter()
                .GetResult();
        }

        public PaellaUser GetUser(HttpContext context)
        {
            var username = context.User.Claims
                .FirstOrDefault(claim => claim.Type == "sub")?.Value;

            return FindByName(username);
        }

        public bool CheckPassword(PaellaUser user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password)
                .GetAwaiter()
                .GetResult();
        }

        public PaellaUser Create(PaellaUser user, string password)
        {
            var result = _userManager.CreateAsync(user, password)
                .GetAwaiter()
                .GetResult();

            if (result.Succeeded)
            {
                return FindByName(user.UserName);
            }

            throw new Exception(result.ToString());
        }


    }
}
