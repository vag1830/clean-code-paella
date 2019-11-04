using System.Collections.Generic;
using Paella.Domain.Entities;

namespace Paella.Application.UseCases.GetAll
{
    public interface IGetAllUseCase
    {
        ICollection<Product> Execute();
    }
}