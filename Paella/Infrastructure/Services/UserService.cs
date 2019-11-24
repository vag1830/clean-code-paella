using System;
using Microsoft.AspNetCore.Identity;
using Paella.Application.Services;
using Paella.Infrastructure.Entities;

namespace Paella.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private UserManager<PaellaUser> _userManager;

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
