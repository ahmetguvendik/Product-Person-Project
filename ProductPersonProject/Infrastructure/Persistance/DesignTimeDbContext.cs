using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistance.Contexts;

namespace Persistance
{
	public class DesignTimeDbContext : IDesignTimeDbContextFactory<ProductDbContext>
    {
		
        public ProductDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ProductDbContext> dbContextOptions = new();
            dbContextOptions.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=ProductDb;");
            return new(dbContextOptions.Options);
        }
    }
}

