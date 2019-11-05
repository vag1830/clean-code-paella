using System;
using System.Collections.Generic;
using System.Linq;
using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Domain.Exceptions;

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

        public void Create(Product product)
        {
            // TODO: this check should be moved to the usecase using equality
            if (Products.Values.Any(p => string.Equals(p.Name, product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ProductAlreadyExistsException();
            }

            Products.Add(product.Id, product);
        }
    }
}