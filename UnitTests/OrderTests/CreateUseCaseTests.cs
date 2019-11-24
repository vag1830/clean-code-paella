using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Paella.Application.OrderUseCases.Create;
using Paella.Application.OrderUseCases.Create.Parameters;
using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Domain.Exceptions;
using Paella.Infrastructure;
using Xunit;

namespace UnitTests.OrderTests
{
    public class CreateUseCaseTests
    {
        private readonly Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();
        private readonly Mock<ICustomerRepository> _customerRepository = new Mock<ICustomerRepository>();

        [Fact]
        public void CustomerDoesNotExist_ShouldThrowExpectedException()
        {
            // Arrange
            _customerRepository
                .Setup(repository => repository.GetById(It.IsAny<Guid>()))
                .Returns(null as Customer);

            var sut = GetSut();
            var productIdQuantityDictionary = new Dictionary<Guid, int> { { Guid.NewGuid(), 1 } };
            var customerId = Guid.NewGuid();
            var input = new CreateInput(customerId, productIdQuantityDictionary);

            // Act
            Action action = () => sut.Execute(input);

            // Assert
            action
                .Should()
                .Throw<CustomerNotFoundException>()
                .WithMessage($"{typeof(CreateUseCase)}: Customer with id: {customerId}, does not exist.");
        }

        [Fact]
        public void ProductDoesNotExist_ShouldThrowExpectedException()
        {
            // Arrange
            _customerRepository
                .Setup(repository => repository.GetById(It.IsAny<Guid>()))
                .Returns(new Customer());

            _productRepository
                .Setup(repository => repository.Exists(It.IsAny<Guid>()))
                .Returns(false);

            var sut = GetSut();
            var productId = Guid.NewGuid();
            var productIdQuantityDictionary = new Dictionary<Guid, int> { { productId, 1 } };
            var input = new CreateInput(Guid.NewGuid(), productIdQuantityDictionary);

            // Act
            Action action = () => sut.Execute(input);

            // Assert
            action
                .Should()
                    .Throw<ProductNotFoundException>()
                    .WithMessage($"{typeof(CreateUseCase)}: Product with id: {productId}, does not exist.");
        }

        [Fact]
        public void ValidInput_ShouldCreateTheOrder()
        {
            // Arrange
            _customerRepository
                .Setup(repository => repository.GetById(It.IsAny<Guid>()))
                .Returns(new Customer());

            _productRepository
                .Setup(repository => repository.Exists(It.IsAny<Guid>()))
                .Returns(true);

            var sut = GetSut();
            var productId = Guid.NewGuid();
            var productIdQuantityDictionary = new Dictionary<Guid, int> { { productId, 1 } };
            var input = new CreateInput(Guid.NewGuid(), productIdQuantityDictionary);

            // Act
            Action action = () => sut.Execute(input);

            // Assert
            action
                .Should()
                .NotThrow();
        }

        private CreateUseCase GetSut()
        {
            var repository = new InMemoryOrderRepository();

            return new CreateUseCase(
                repository,
                _customerRepository.Object,
                _productRepository.Object);
        }
    }
}