using System;
using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Domain.Exceptions;

namespace Paella.Application.UseCases.Update
{
    public class UpdateUseCase : IUpdateUseCase
    {
        private readonly IProductRepository _repository;

        public UpdateUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, Product product)
        {
            var existingProduct = _repository.GetById(id);

            if (existingProduct == null)
            {
                throw new ProductNotFoundException();
            }

            _repository.Update(id, product);
        }
    }
}