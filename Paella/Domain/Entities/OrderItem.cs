using System;

namespace Paella.Domain.Entities
{
    public class OrderItem
    {
        public int Quantity { get; }

        public Guid ProductId { get; }

        public OrderItem(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}