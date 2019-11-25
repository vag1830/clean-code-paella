using System;
using Microsoft.AspNetCore.Identity;

namespace Paella.Infrastructure.Entities
{
    public class PaellaUser : IdentityUser
    {
        public Guid CustomerId { get; set; }

        public CustomerDao Customer { get; set; }
    }
}
