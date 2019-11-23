using System;
using FluentAssertions;
using Paella.Application.Persistence;
using Paella.Application.ProductUseCases.Create;
using Paella.Application.ProductUseCases.Create.Parameters;
using Paella.Application.ProductUseCases.GetById;
using Paella.Application.ProductUseCases.Update;
using Paella.Application.ProductUseCases.Update.Parameters;
using Paella.Domain.Exceptions;
using Paella.Infrastructure;
using Xunit;

namespace UnitTests.ProductTests
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
            var updateInput = new UpdateInput { Id = id, Name = "Name", Description = "Description" };

            // Act
            Action action = () => sut.Execute(updateInput);

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
            var createInput = new CreateInput { Id = id, Name = "Name", Description = "Description" };
            var UpdateInput = new UpdateInput { Id = id, Name = "Name", Description = "Description" };

            createUseCase.Execute(createInput);

            // Act
            sut.Execute(UpdateInput);

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