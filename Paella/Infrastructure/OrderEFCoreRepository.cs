using System;
using System.Linq;
using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Infrastructure.Entities;

namespace Paella.Infrastructure
{
    public class OrderEFCoreRepository : IOrderRepository
    {
        private readonly PaellaDbContext _context;

        public OrderEFCoreRepository(PaellaDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public Order GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Create(Order order)
        {
            var dao = ToDao(order);

            _context.Orders
                .Add(dao);

            _context.SaveChanges();
        }

        private Product ToDomainEntity(ProductDao dao)
        {
            return new Product(dao.Id, dao.Name, dao.Description);
        }

        private OrderDao ToDao(Order order)
        {
            var customer = _context.Customers
                .FirstOrDefault(customer => customer.Id == order.CustomerId);

            return new OrderDao
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                Customer = customer,
                Items = order.Items.All
                    .Select(item => ToOrderItemDao(order.Id, item))
                    .ToList()
            };
        }

        private OrderItemDao ToOrderItemDao(Guid orderId, OrderItem item)
        {
            return new OrderItemDao
            {
                OrderId = orderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
        }
    }
}