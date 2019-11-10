using System;
using Paella.Application.UseCases.Create.Parameters;

namespace Paella.Application.UseCases.Create
{
    public interface ICreateUseCase
    {
        Guid Execute(CreateInput input);
    }
}
