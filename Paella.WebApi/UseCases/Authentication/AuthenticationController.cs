using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Paella.Application.UseCases.Authenticate;
using Paella.WebApi.UseCases.Authentication.Create;
using WebApi.Services;

namespace Paella.WebApi.UseCases.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateUseCase _useCase;
        private readonly TokenService _tokenService;

        public AuthenticationController(
            IAuthenticateUseCase useCase,
            TokenService tokenService)
        {
            _useCase = useCase;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("tokens")]
        public IActionResult CreateToken([FromBody] CreateTokenRequest request)
        {
            try
            {
                var input = new AuthenticationInput(request.UserName, request.Password);
                var user = _useCase.Execute(input);
                var token = _tokenService.CreateToken(user);

                var response = new CreateTokenResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expires = token.ValidTo
                };

                return Created("https://paella.com", response);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}