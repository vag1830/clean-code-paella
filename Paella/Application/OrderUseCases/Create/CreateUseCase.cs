using System;
using System.Collections.Generic;
using Paella.Application.OrderUseCases.Create.Parameters;
using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Domain.Entities.Collections;
using Paella.Domain.Exceptions;

namespace Paella.Application.OrderUseCases.Create
{
    public class CreateUseCase : ICreateUseCase
    {
        private readonly IOrderRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CreateUseCase(
            IOrderRepository repository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository)
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public Guid Execute(CreateInput input)
        {
            ValidateCustomerIdAndThrow(input.CustomerId);
            ValidateOrderItemsAndThrow(input.ProductIdQuantityDictionary);

            var order = ToDomainEntity(input);

            _repository.Create(order);

            return order.Id;
        }

        private void ValidateCustomerIdAndThrow(Guid customerId)
        {
            var customer = _customerRepository.GetById(customerId);

            if (customer == null)
            {
                throw new CustomerNotFoundException($"{typeof(CreateUseCase)}: Customer with id: {customerId}, does not exist.");
            }
        }

        private void ValidateOrderItemsAndThrow(IDictionary<Guid, int> productIdQuantityDictionary)
        {
            foreach (var item in productIdQuantityDictionary)
            {
                if (_productRepository.Exists(item.Key) == false)
                {
                    throw new ProductNotFoundException($"{typeof(CreateUseCase)}: Product with id: {item.Key}, does not exist.");
                }
            }
        }

        private Order ToDomainEntity(CreateInput input)
        {
            var orderItems = new OrderItems();

            foreach (var item in input.ProductIdQuantityDictionary)
            {
                orderItems.Add(item.Key, item.Value);
            }

            var order = new Order(input.CustomerId, orderItems);

            return order;
        }
    }
}