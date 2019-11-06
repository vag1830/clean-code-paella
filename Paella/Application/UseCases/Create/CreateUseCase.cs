using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Domain.Exceptions;

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
            var exists = _repository.GetById(product.Id) == null
                ? false
                : true;

            if (exists)
            {
                throw new ProductAlreadyExistsException();
            }

            _repository.Create(product);
        }
    }
}