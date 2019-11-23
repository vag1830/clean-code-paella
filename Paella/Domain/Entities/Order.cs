using System;
using Paella.Domain.Entities.Collections;

namespace Paella.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public PaellaUser User { get; }

        public OrderItems Items { get; }

        public DateTime CreatedDate { get; }

        public Order(PaellaUser user, OrderItems items, DateTime createdDate)
        {
            User = user;
            Items = items;
            CreatedDate = createdDate;
        }
    }
}