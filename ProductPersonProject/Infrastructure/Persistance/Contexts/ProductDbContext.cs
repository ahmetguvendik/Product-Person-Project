using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Contexts
{
	public class ProductDbContext : DbContext
	{
        public ProductDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}

