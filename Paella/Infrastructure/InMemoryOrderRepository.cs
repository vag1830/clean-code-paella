using System;
using System.Collections.Generic;
using System.Linq;
using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Domain.Entities.Collections;

namespace Paella.Infrastructure
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly IDictionary<Guid, Order> Orders = new Dictionary<Guid, Order>();

        public InMemoryOrderRepository()
        {
            //var order = CreateOrder();

            //Orders.Add(order.Id, order);
        }

        public IList<Order> GetAll()
        {
            return Orders.Values
                .ToList();
        }

        public Order GetById(Guid id)
        {
            Orders.TryGetValue(id, out var order);

            return order;
        }

        public Order CreateAndAddNewOrder()
        {
            var customer = new Customer();
            var product = new Product("name", "description");
            var orderItem = new OrderItem(product, 1);
            var orderItems = new List<OrderItem> { orderItem };
            var items = new OrderItems(orderItems);

            var order = new Order(customer.Id, items);

            Orders.Add(order.Id, order);

            return order;
        }
    }
}