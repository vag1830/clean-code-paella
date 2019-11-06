using System.ComponentModel.DataAnnotations;

namespace Paella.WebApi.UseCases.Update
{
    public class UpdateProductRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
