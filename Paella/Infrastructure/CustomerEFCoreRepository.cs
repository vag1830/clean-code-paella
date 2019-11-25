using System;
using System.Linq;
using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Infrastructure.Entities;

namespace Paella.Infrastructure
{
    public class CustomerEFCoreRepository : ICustomerRepository
    {
        private readonly PaellaDbContext _context;

        public CustomerEFCoreRepository(PaellaDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        Customer ICustomerRepository.GetById(Guid id)
        {
            var result = _context.Customers
                .FirstOrDefault(customer => customer.Id == id);

            return result == null
                ? null
                : ToDomainEntity(result);
        }

        public void Create(Customer order)
        {
            throw new NotImplementedException();
        }

        private Customer ToDomainEntity(CustomerDao dao)
        {
            return new Customer(dao.Id);
        }
    }
}