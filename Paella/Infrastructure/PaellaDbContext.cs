using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paella.Domain.Entities;
using Paella.Infrastructure.Entities;

namespace Paella.Infrastructure
{
    public class PaellaDbContext : IdentityDbContext<PaellaUser>
    {
        public DbSet<ProductDao> Products { get; set; }

        public DbSet<OrderDao> Orders { get; set; }

        public DbSet<OrderItemDao> OrderItems { get; set; }

        public DbSet<CustomerDao> Customers { get; set; }

        public PaellaDbContext(DbContextOptions<PaellaDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductDao>(entity =>
            {
                entity.HasKey(product => product.Id);
            });

            modelBuilder.Entity<OrderDao>(entity =>
            {
                entity.HasKey(order => order.Id);
                entity.HasOne(order => order.Customer);
                entity.HasMany(order => order.Items);
            });

            modelBuilder.Entity<OrderItemDao>(entity =>
            {
                entity.HasKey(item => new { item.OrderId, item.ProductId });
                entity.HasOne(item => item.Order);
                entity.HasOne(item => item.Product);
            });

            modelBuilder.Entity<CustomerDao>(entity =>
            {
                entity.HasKey(customer => customer.Id);
                entity.HasMany(customer => customer.Orders);
            });
        }
    }
}