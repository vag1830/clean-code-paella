using System;
using Paella.Domain.Entities.Collections;

namespace Paella.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; }

        public Guid CustomerId { get; }

        public OrderItems Items { get; }

        public DateTime CreatedDate { get; }

        public Order(Guid customerId, OrderItems items)
        {
            Id = Guid.NewGuid();

            CustomerId = customerId;
            Items = items;

            CreatedDate = DateTime.UtcNow;
        }
    }
}