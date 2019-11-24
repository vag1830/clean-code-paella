using System;
using System.Collections.Generic;
using Paella.Domain.Entities;

namespace Paella.Application.Persistence
{
    public interface IProductRepository
    {
        ICollection<Product> GetAll();

        Product GetById(Guid id);

        void Create(Product product);

        void Update(Product product);

        bool Exists(Guid id);
    }
}