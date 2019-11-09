using Microsoft.EntityFrameworkCore;
using Paella.Infrastructure.Entities;

namespace Paella.Infrastructure
{
    public class ProductDbContext : DbContext
    {
        public DbSet<ProductDao> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDao>(entity =>
            {
                entity.HasKey(product => product.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
