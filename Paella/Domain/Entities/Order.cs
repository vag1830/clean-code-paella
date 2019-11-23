using System;
using Paella.Domain.Entities.Collections;

namespace Paella.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; }

        public OrderItems Items { get; }

        public DateTime CreatedDate { get; }

        public Order(Guid customerId, OrderItems items)
        {
            if (items == null || items.Count < 1)
            {
                throw new ArgumentException($"{typeof(OrderItems)} cannot be null or empty.");
            }

            Id = Guid.NewGuid();

            CustomerId = customerId;
            Items = items;

            CreatedDate = DateTime.UtcNow;
        }
    }
}