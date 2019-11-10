using System;
using Paella.Application.Services;
using Paella.Domain.Entities;

namespace Paella.Application.UseCases.Authenticate
{
    public class AuthenticateUseCase : IAuthenticateUseCase
    {
        private IUserService _userService;

        public AuthenticateUseCase(IUserService userService)
        {
            _userService = userService;
        }

        public PaellaUser Execute(AuthenticationInput input)
        {
            var user = _userService.FindByName(input.UserName);

            if (user != null && _userService.CheckPassword(user, input.Password))
            {
                return user;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}