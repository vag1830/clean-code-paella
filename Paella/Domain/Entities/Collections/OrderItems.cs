using System;
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

        public int Count => Items.Count;

        public void Add(Guid productId, int quantity)
        {
            Items.Add(new OrderItem(productId, quantity));
        }
    }
}