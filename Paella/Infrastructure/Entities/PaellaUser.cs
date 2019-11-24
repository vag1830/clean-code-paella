using Microsoft.AspNetCore.Identity;

namespace Paella.Infrastructure.Entities
{
    public class PaellaUser : IdentityUser
    {
        public CustomerDao Customer { get; set; }
    }
}
