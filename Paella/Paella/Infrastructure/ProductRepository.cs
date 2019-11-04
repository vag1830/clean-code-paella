using System;
using System.Collections.Generic;
using System.Linq;
using Paella.Application.Persistence;
using Paella.Domain.Entities;

namespace Paella.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDictionary<Guid, Product> Products = new Dictionary<Guid, Product>();

        public ProductRepository()
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
            return Products[id];
        }
    }
}