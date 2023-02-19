using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Laptop", Quality = 10, Quantity = 149, CreateDate = DateTime.Now },
                 new Product() { Id = Guid.NewGuid(), Name = "Mobile Phone", Quality = 10, Quantity = 52, CreateDate = DateTime.Today },
                  new Product() { Id = Guid.NewGuid(), Name = "TV", Quality = 10, Quantity = 257, CreateDate = DateTime.UtcNow },
                   new Product() { Id = Guid.NewGuid(), Name = "Desktop PC", Quality = 10, Quantity = 124, CreateDate = DateTime.Now }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
