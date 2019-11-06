using System;
using System.Collections.Generic;
using System.Linq;
using Paella.Application.Persistence;
using Paella.Domain.Entities;

namespace Paella.Infrastructure
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly IDictionary<Guid, Product> Products = new Dictionary<Guid, Product>();

        public InMemoryProductRepository()
        {
            var product = new Product("Tapas", "Delicious");

            Products.Add(product.Id, product);
        }

        public ICollection<Product> GetAll()
        {
            return Products.Values.ToList();
        }

        public Product GetById(Guid id)
        {
            Products.TryGetValue(id, out var product);

            return product;
        }

        public void Create(Product product)
        {
            Products.Add(product.Id, product);
        }

        public void Update(Guid id, Product product)
        {
            Products[id] = product;
        }
    }
}