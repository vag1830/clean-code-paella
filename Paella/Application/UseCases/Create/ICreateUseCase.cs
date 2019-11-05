using Paella.Domain.Entities;

namespace Paella.Application.UseCases.Create
{
    public interface ICreateUseCase
    {
        void Execute(Product product);
    }
}
