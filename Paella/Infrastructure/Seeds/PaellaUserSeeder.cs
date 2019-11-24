using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Paella.Domain.Entities;

namespace Paella.Infrastructure.Seeds
{
    public class PaellaUserSeeder : ISeeder
    {
        private readonly PaellaDbContext _context;
        private readonly UserManager<PaellaUser> _userManager;

        public PaellaUserSeeder(PaellaDbContext context, UserManager<PaellaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Users.Any())
            {
                var user = new PaellaUser
                {
                    Email = "a@b.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "username"
                };

                _userManager.CreateAsync(user, "P@ssword!23")
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}
