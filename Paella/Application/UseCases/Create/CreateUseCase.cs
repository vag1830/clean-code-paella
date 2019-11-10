using System;
using Paella.Application.Persistence;
using Paella.Application.UseCases.Create.Parameters;
using Paella.Domain.Entities;

namespace Paella.Application.UseCases.Create
{
    public class CreateUseCase : ICreateUseCase
    {
        private readonly IProductRepository _repository;

        public CreateUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public Guid Execute(CreateInput input)
        {
            var product = _repository.GetById(input.Id);

            if (product != null)
            {
                return product.Id;
            }

            product = new Product(
                input.Id,
                input.Name,
                input.Description);

            _repository.Create(product);

            return product.Id;
        }
    }
}