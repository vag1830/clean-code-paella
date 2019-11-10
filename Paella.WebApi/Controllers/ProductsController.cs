using System;
using Microsoft.AspNetCore.Mvc;
using Paella.Application.UseCases.Create;
using Paella.Application.UseCases.Create.Parameters;
using Paella.Application.UseCases.GetAll;
using Paella.Application.UseCases.GetById;
using Paella.Application.UseCases.Update;
using Paella.Domain.Entities;
using Paella.Domain.Exceptions;
using Paella.WebApi.UseCases.Create;
using Paella.WebApi.UseCases.Update;

namespace Paella.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGetAllUseCase _getAllUseCase;
        private readonly IGetByIdUseCase _getByIdUseCase;
        private readonly ICreateUseCase _createUseCase;
        private readonly IUpdateUseCase _updateUseCase;

        public ProductsController(
            IGetAllUseCase getAllUseCase,
            IGetByIdUseCase getByIdUseCase,
            ICreateUseCase createUseCase,
            IUpdateUseCase updateUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
            _createUseCase = createUseCase;
            _updateUseCase = updateUseCase;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _getAllUseCase.Execute();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _getByIdUseCase.Execute(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateProductRequest request)
        {
            var input = new CreateInput
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description
            };

            var productId = _createUseCase.Execute(input);

            return Ok(productId);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, UpdateProductRequest request)
        {
            try
            {
                var product = new Product(id, request.Name, request.Description);

                _updateUseCase.Execute(id, product);
            }
            catch (ProductNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}