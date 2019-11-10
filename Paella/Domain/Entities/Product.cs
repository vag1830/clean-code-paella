using System;

namespace Paella.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public Product(string name, string description)
        {
            Id = Guid.NewGuid();

            Name = name;
            Description = description;
        }

        public Product(
            Guid id,
            string name,
            string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}