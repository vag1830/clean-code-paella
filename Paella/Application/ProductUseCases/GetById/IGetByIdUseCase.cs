using System;
using Paella.Domain.Entities;

namespace Paella.Application.ProductUseCases.GetById
{
    public interface IGetByIdUseCase
    {
        Product Execute(Guid id);
    }
}
