using System;
using System.Linq;
using Paella.Infrastructure.Entities;

namespace Paella.Infrastructure.Seeds
{
    public class PaellaProductSeeder
    {
        private readonly PaellaDbContext _context;

        public PaellaProductSeeder(PaellaDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (_context.Products.ToList().Count > 10)
            {
                return;
            }

            for (var i = 0; i < 10; i++)
            {
                _context.Products.Add(new ProductDao
                {
                    Id = Guid.NewGuid(),
                    Name = "product name",
                    Description = "product description"
                });
            }

            _context.SaveChanges();
        }
    }
}
