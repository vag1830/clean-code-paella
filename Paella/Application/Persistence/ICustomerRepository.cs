using System;
using Paella.Domain.Entities;

namespace Paella.Application.Persistence
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);

        void Create(Customer order);
    }
}