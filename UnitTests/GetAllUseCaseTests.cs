using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Paella.Application.Persistence;
using Paella.Application.UseCases.GetAll;
using Paella.Domain.Entities;
using Xunit;

namespace UnitTests
{
    public class GetAllUseCaseTests
    {
        [Fact]
        public void NoProductsAvailable_ShouldReturnEmptyList()
        {
            // Arrange
            var repository = GetEmptyProductRepository();
            var sut = new GetAllUseCase(repository);

            // Act
            var actual = sut.Execute();

            // Assert
            actual
                .Should()
                .BeEmpty();

        }

        [Fact]
        public void ProductsAvailable_ShouldReturnAListOfProducts()
        {
            // Arrange
            var repository = GetProductRepository();
            var sut = new GetAllUseCase(repository);

            // Act
            var actual = sut.Execute();

            // Assert
            actual
                .Should()
                .NotBeEmpty();

            actual.Count
                .Should()
                .Be(1);
        }

        private IProductRepository GetEmptyProductRepository()
        {
            var repository = new Mock<IProductRepository>();

            repository
                .Setup(r => r.GetAll())
                .Returns(new List<Product>());

            return repository.Object;
        }

        private IProductRepository GetProductRepository()
        {
            var repository = new Mock<IProductRepository>();
            var products = new List<Product>
            {
                new Product("Name", "Description")
            };

            repository
                .Setup(r => r.GetAll())
                .Returns(products);

            return repository.Object;
        }
    }
}