using System;
using System.Collections.Generic;

namespace Paella.Application.OrderUseCases.Create.Parameters
{
    public class CreateInput
    {
        public Guid CustomerId { get; }

        public IDictionary<Guid, int> ProductIdQuantityDictionary { get; }

        public CreateInput(
            Guid customerId,
            IDictionary<Guid, int> productIdQuantityDictionary)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException($"{typeof(CreateInput)}: customerId cannot be empty.");
            }

            if (productIdQuantityDictionary == null || productIdQuantityDictionary.Count < 1)
            {
                throw new ArgumentException($"{typeof(CreateInput)}: productIdQuantityDictionary cannot be null or empty.");
            }

            CustomerId = customerId;
            ProductIdQuantityDictionary = productIdQuantityDictionary;
        }
    }
}