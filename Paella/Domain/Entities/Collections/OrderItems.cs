using System;
using System.Collections.Generic;

namespace Paella.Domain.Entities.Collections
{
    public class OrderItems
    {
        private ICollection<OrderItem> _items;

        public IReadOnlyCollection<OrderItem> All => new List<OrderItem>(_items);

        public OrderItems()
        {
            _items = new List<OrderItem>();
        }

        public OrderItems(ICollection<OrderItem> items)
        {
            _items = items;
        }

        public int Count => _items.Count;

        public void Add(Guid productId, int quantity)
        {
            _items.Add(new OrderItem(productId, quantity));
        }
    }
}