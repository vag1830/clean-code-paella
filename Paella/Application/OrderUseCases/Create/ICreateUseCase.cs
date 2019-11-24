using System;
using Paella.Application.OrderUseCases.Create.Parameters;

namespace Paella.Application.OrderUseCases.Create
{
    public interface ICreateUseCase
    {
        Guid Execute(CreateInput input);
    }
}
