using System.ComponentModel.DataAnnotations;

namespace Paella.WebApi.UseCases.Create
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
