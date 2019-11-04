using System;
using Microsoft.AspNetCore.Mvc;
using Paella.Application.UseCases.GetAll;

namespace Paella.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGetAllUseCase _getAllUseCase;

        public ProductsController(IGetAllUseCase getAllUseCase)
        {
            _getAllUseCase = getAllUseCase;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var result = _getAllUseCase.Execute();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            return Ok();
        }
    }
}