﻿using System;
using Microsoft.AspNetCore.Mvc;
using Paella.Application.ProductUseCases.Create;
using Paella.Application.ProductUseCases.Create.Parameters;
using Paella.Application.ProductUseCases.GetAll;
using Paella.Application.ProductUseCases.GetById;
using Paella.Application.ProductUseCases.Update.Parameters;
using Paella.Application.UseCases.Update;
using Paella.Domain.Exceptions;
using Paella.WebApi.UseCases.Product.Create;
using Paella.WebApi.UseCases.Product.Update;

namespace Paella.WebApi.UseCases.Product
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
        // [Authorize]
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
        // [Authorize]
        public IActionResult Update(Guid id, UpdateProductRequest request)
        {
            try
            {
                var input = new UpdateInput
                {
                    Id = id,
                    Name = request.Name,
                    Description = request.Description
                };

                var productId = _updateUseCase.Execute(input);

                return Ok(productId);
            }
            catch (ProductNotFoundException)
            {
                return NotFound();
            }
        }
    }
}