using System.ComponentModel.DataAnnotations;

namespace Paella.WebApi.UseCases.Product.Update
{
    public class UpdateProductRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
