using System.Collections.Generic;
using Paella.Domain.Entities;

namespace Paella.Application.ProductUseCases.GetAll
{
    public interface IGetAllUseCase
    {
        ICollection<Product> Execute();
    }
}