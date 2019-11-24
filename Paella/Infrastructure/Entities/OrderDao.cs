using System;
using System.Collections.Generic;

namespace Paella.Infrastructure.Entities
{
    public class OrderDao
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public CustomerDao Customer { get; set; }

        public ICollection<OrderItemDao> Items { get; set; }
    }
}
