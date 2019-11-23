using System.Collections.Generic;

namespace Paella.Domain.Entities.Collections
{
    public class OrderItems
    {
        ICollection<OrderItem> Items { get; }

        public OrderItems()
        {
            Items = new List<OrderItem>();
        }

        public OrderItems(ICollection<OrderItem> items)
        {
            Items = items;
        }
    }
}