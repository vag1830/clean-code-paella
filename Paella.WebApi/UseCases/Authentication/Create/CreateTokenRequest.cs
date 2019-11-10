using System.ComponentModel.DataAnnotations;

namespace Paella.WebApi.UseCases.Authentication.Create
{
    public class CreateTokenRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}