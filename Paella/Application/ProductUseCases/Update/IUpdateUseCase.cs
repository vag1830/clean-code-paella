﻿using System;
using Paella.Application.ProductUseCases.Update.Parameters;

namespace Paella.Application.UseCases.Update
{
    public interface IUpdateUseCase
    {
        Guid Execute(UpdateInput input);
    }
}