using Paella.Application.Persistence;
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

        public void Execute(Product product)
        {
            _repository.Create(product);
        }
    }
}