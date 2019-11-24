using System;
using System.Collections.Generic;
using FluentAssertions;
using Paella.Application.OrderUseCases.Create.Parameters;
using Xunit;

namespace UnitTests.OrderTests
{
    public class CreateInputTests
    {
        [Fact]
        public void CustomerIdIsEmpty_ShouldThrowExpectedException()
        {
            // Act
            Action action = () => new CreateInput(Guid.Empty, new Dictionary<Guid, int>());

            // Assert
            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage($"{typeof(CreateInput)}: customerId cannot be empty.");
        }

        [Fact]
        public void OrderItemsIsEmpty_ShouldThrowExpectedException()
        {
            // Act
            Action action = () => new CreateInput(Guid.NewGuid(), new Dictionary<Guid, int>());

            // Assert
            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage($"{typeof(CreateInput)}: productIdQuantityDictionary cannot be null or empty.");
        }

        [Fact]
        public void OrderItemsIsNull_ShouldThrowExpectedException()
        {
            // Act
            Action action = () => new CreateInput(Guid.NewGuid(), null);

            // Assert
            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage($"{typeof(CreateInput)}: productIdQuantityDictionary cannot be null or empty.");
        }
    }
}