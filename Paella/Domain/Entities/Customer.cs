using System;

namespace Paella.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; }

        public Customer()
        {
            Id = Guid.NewGuid();
        }
    }
}
