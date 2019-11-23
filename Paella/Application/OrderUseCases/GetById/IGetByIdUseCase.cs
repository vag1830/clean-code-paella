using System;
using Paella.Domain.Entities;

namespace Paella.Application.OrderUseCases.GetById
{
    public interface IGetByIdUseCase
    {
        Order Execute(Guid id);
    }
}