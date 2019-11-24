using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paella.Infrastructure.Entities
{
    public class OrderItemDao
    {
        [ForeignKey(nameof(OrderDao))]
        public Guid OrderId { get; set; }

        public OrderDao Order { get; set; }

        [ForeignKey(nameof(ProductDao))]
        public Guid ProductId { get; set; }

        public ProductDao Product { get; set; }

        public int Quantity { get; set; }
    }
}