using System;
using Paella.Application.OrderUseCases.Create.Parameters;
using Paella.Application.Persistence;
using Paella.Domain.Entities;

namespace Paella.Application.OrderUseCases.Create
{
    public class CreateUseCase : ICreateUseCase
    {
        private readonly IOrderRepository _repository;

        public CreateUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Guid Execute(CreateInput input)
        {
            // NOTES: Creates a new Order
            // - An order must come from a customer
            // - An order must contain at least one Item
            // - Each item on the order is a tuple of (Product, Qty)
            // - Each item on the order must have availability for the requested Qty

            var order = ToDomainEntity(input);

            _repository.Create(order);

            return order.Id;
        }

        private Order ToDomainEntity(CreateInput input)
        {
            var order = new Order(input.CustomerId, null);

            return order;
        }
    }
}
