using System;
using System.Collections.Generic;

namespace Paella.Application.OrderUseCases.Create.Parameters
{
    public class CreateInput
    {
        public Guid CustomerId { get; set; }

        public List<(Guid ProductId, int Quantity)> Items { get; set; }
    }
}