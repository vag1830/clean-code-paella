using System;
using Paella.Domain.Entities;

namespace Paella.Application.UseCases.GetById
{
    public interface IGetByIdUseCase
    {
        Product Execute(Guid id);
    }
}
