using System;
using Paella.Domain.Entities;

namespace Paella.Application.UseCases.Update
{
    public interface IUpdateUseCase
    {
        void Execute(Guid id, Product product);
    }
}