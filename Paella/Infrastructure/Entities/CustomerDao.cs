using System;
using System.Collections.Generic;

namespace Paella.Infrastructure.Entities
{
    public class CustomerDao
    {
        public Guid Id { get; set; }

        public ICollection<OrderDao> Orders { get; set; }
    }
}
