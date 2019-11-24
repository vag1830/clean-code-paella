using System;
using System.Linq;
using FluentAssertions;
using Paella.Application.OrderUseCases.GetById;
using Paella.Infrastructure;
using Xunit;

namespace UnitTests.OrderTests
{
    public class GetByIdUseCaseTests
    {
        [Fact]
        public void OrderDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var repository = GetEmptyOrderRepository();
            var sut = new GetByIdUseCase(repository);

            var id = Guid.NewGuid();

            // Act
            var actual = sut.Execute(id);

            // Assert
            actual
                .Should()
                .BeNull();
        }

        [Fact]
        public void OrderExists_ShouldReturTheExpectedOrder()
        {
            // Arrange
            var repository = GetOrderRepository();
            var sut = new GetByIdUseCase(repository);

            var orderId = repository.GetAll()
                .FirstOrDefault().Id;

            // Act
            var actual = sut.Execute(orderId);

            // Assert
            actual.Id
                .Should()
                .Be(orderId);
        }


        private InMemoryOrderRepository GetEmptyOrderRepository()
        {
            return new InMemoryOrderRepository();
        }

        private InMemoryOrderRepository GetOrderRepository()
        {
            var repository = new InMemoryOrderRepository();

            repository.CreateAndAddNewOrder();

            return repository; ;
        }
    }
}