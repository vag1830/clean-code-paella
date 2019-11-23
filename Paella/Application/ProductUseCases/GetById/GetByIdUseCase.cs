using System;
using Paella.Application.Persistence;
using Paella.Domain.Entities;

namespace Paella.Application.ProductUseCases.GetById
{
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private readonly IProductRepository _repository;

        public GetByIdUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}