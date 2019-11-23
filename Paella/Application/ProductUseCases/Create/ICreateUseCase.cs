using System;
using Paella.Application.ProductUseCases.Create.Parameters;

namespace Paella.Application.ProductUseCases.Create
{
    public interface ICreateUseCase
    {
        Guid Execute(CreateInput input);
    }
}
