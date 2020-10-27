using JON_Store.DomainModel;
using JON_Store.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JON_Store.EntityFrameworkCore.Initializers
{
    public class DefaultDbInitialier : IDbInitializer
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            AddProduct(modelBuilder);
        }

        private void AddProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
            new Product { Id = 1, Name = "Phone", Description = "SOme description", Price = 13.0 },
            new Product { Id = 2, Name = "Laptop", Description = "SOme description", Price = 11.50 },
            new Product { Id = 3, Name = "Clock", Description = "SOme description", Price = 19.30 }
            );
        }
    }
}
