using System;
using System.Collections.Generic;
using System.Linq;
using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Domain.Exceptions;
using Paella.Infrastructure.Entities;
using Paella.Infrastructure.Exceptions;

namespace Paella.Infrastructure
{
    public class ProductEFCoreRepository : IProductRepository
    {
        private readonly PaellaDbContext _context;

        public ProductEFCoreRepository(PaellaDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public ICollection<Product> GetAll()
        {
            var result = _context.Products
                .Select(ToDomainEntity)
                .ToList();

            return result;
        }

        public Product GetById(Guid id)
        {
            var result = _context.Products
                .FirstOrDefault(product => product.Id == id);

            return result == null
                ? null
                : ToDomainEntity(result);
        }

        public void Create(Product product)
        {
            var dao = ToDao(product);

            _context.Products
                .Add(dao);

            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var dao = _context.Products
                    .FirstOrDefault(p => p.Id == product.Id);

                if (dao == null)
                {
                    throw new ProductNotFoundException();
                }

                dao.Name = product.Name;
                dao.Description = product.Description;

                _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(ex.Message, ex);
            }
        }

        private Product ToDomainEntity(ProductDao dao)
        {
            return new Product(dao.Id, dao.Name, dao.Description);
        }

        private ProductDao ToDao(Product product)
        {
            return new ProductDao
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            };
        }
    }
}