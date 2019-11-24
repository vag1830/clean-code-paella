using System;

namespace Paella.Infrastructure.Entities
{
    public class OrderItemDao
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}