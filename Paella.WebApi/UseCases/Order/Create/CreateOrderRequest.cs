using System;
using System.Collections.Generic;

namespace Paella.WebApi.UseCases.Order.Create
{
    public class CreateOrderRequest
    {
        public IDictionary<Guid, int> ProductIdQuantityDictionary { get; set; }
    }
}