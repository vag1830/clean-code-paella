using System;
using Paella.Application.Persistence;
using Paella.Application.UseCases.Update.Parameters;
using Paella.Domain.Entities;

namespace Paella.Application.UseCases.Update
{
    public class UpdateUseCase : IUpdateUseCase
    {
        private readonly IProductRepository _repository;

        public UpdateUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public Guid Execute(UpdateInput input)
        {
            var product = new Product(input.Id, input.Name, input.Description);

            _repository.Update(product);

            return input.Id;
        }
    }
}