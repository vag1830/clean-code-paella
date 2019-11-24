using System;
using Paella.Domain.Entities;

namespace Paella.Application.Persistence
{
    public interface IOrderRepository
    {
        Order GetById(Guid id);
        void Create(Order order);
    }
}