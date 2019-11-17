using System;

namespace Paella.WebApi.UseCases.Authentication.Create
{
    public class CreateTokenResponse
    {
        public string Token { get; set; }

        public DateTime Expires { get; set; }
    }
}