using System;
using Paella.Infrastructure.Entities;
using Paella.WebApi.AuthenticationUseCases.Parameters;
using Paella.WebApi.Services;

namespace Paella.WebApi.AuthenticationUseCases
{
    public class AuthenticateUseCase : IAuthenticateUseCase
    {
        private readonly IUserService _userService;

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