using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(e => e.Id);
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Description).HasMaxLength(100);
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}
    

