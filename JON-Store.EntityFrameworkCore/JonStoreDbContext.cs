using JON_Store.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace JON_Store.EntityFrameworkCore
{
    public class JonStoreDbContext : DbContext
    {
        private readonly IDbInitializer _dbInitialier;

        public JonStoreDbContext(DbContextOptions options, IDbInitializer dbInitialier)
            : base(options)
        {
            _dbInitialier = dbInitialier;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JonStoreDbContext).Assembly);

            _dbInitialier.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
