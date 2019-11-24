using System;
using System.Linq;
using Paella.Infrastructure.Entities;

namespace Paella.Infrastructure.Seeds
{
    public class CustomerSeeder : ISeeder
    {
        private readonly PaellaDbContext _context;

        public CustomerSeeder(PaellaDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Customers.Any())
            {
                if (_context.Customers.ToList().Count > 10)
                {
                    return;
                }

                for (var i = 0; i < 10; i++)
                {
                    _context.Customers.Add(new CustomerDao
                    {
                        Id = Guid.NewGuid()
                    });
                }

                _context.SaveChanges();
            }
        }
    }
}
