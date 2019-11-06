using System;
using FluentAssertions;
using Paella.Application.Persistence;
using Paella.Application.UseCases.Create;
using Paella.Application.UseCases.GetById;
using Paella.Application.UseCases.Update;
using Paella.Domain.Entities;
using Paella.Domain.Exceptions;
using Paella.Infrastructure;
using Xunit;

namespace UnitTests
{
    public class UpdateUseCaseTests
    {
        [Fact]
        public void TheProductDoesNotExist_ShouldThrowException()
        {
            // Arrange
            var repository = GetEmptyProductRepository();
            var sut = new UpdateUseCase(repository);

            var id = Guid.NewGuid();
            var product = new Product(id, "Name", "Description");

            // Act
            Action action = () => sut.Execute(id, product);

            // Assert
            action
                .Should()
                .Throw<ProductNotFoundException>();
        }

        [Fact]
        public void TheProductExists_ShouldUpdateTheProduct()
        {
            // Arrange
            var repository = GetEmptyProductRepository();
            var sut = new UpdateUseCase(repository);

            var createUseCase = new CreateUseCase(repository);
            var getByIdUseCase = new GetByIdUseCase(repository);

            var id = Guid.NewGuid();
            var product = new Product(id, "Name", "Description");

            createUseCase.Execute(product);

            // Act
            sut.Execute(id, product);

            var actual = getByIdUseCase.Execute(id);

            // Assert
            actual.Id
                .Should()
                .Be(id);
        }

        private IProductRepository GetEmptyProductRepository()
        {
            var repository = new InMemoryProductRepository();

            return repository;
        }
    }
}