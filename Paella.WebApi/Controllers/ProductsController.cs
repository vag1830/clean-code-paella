using System;
using Microsoft.AspNetCore.Mvc;
using Paella.Application.UseCases.GetAll;
using Paella.Application.UseCases.GetById;

namespace Paella.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGetAllUseCase _getAllUseCase;
        private readonly IGetByIdUseCase _getByIdUseCase;

        public ProductsController(
            IGetAllUseCase getAllUseCase,
            IGetByIdUseCase getByIdUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
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
            var result = _getByIdUseCase.Execute(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}