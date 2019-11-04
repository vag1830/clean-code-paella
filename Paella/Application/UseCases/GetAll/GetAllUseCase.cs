using System.Collections.Generic;
using Paella.Application.Persistence;
using Paella.Domain.Entities;

namespace Paella.Application.UseCases.GetAll
{
    public class GetAllUseCase : IGetAllUseCase
    {
        private readonly IProductRepository _repository;

        public GetAllUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Product> Execute()
        {
            return _repository.GetAll();
        }
    }
}