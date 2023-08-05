using System;
using Application.Repositories;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;
using Persistance.Services;

namespace Persistance
{
	public static class ServiceRegistration
	{
        public static void AddPersistanceService(this IServiceCollection collection)
        {
            collection.AddDbContext<ProductDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=ProductDb;"));
            collection.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            collection.AddScoped<IProductReadRepository, ProductReadRepository>();
            collection.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            collection.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            collection.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
            collection.AddScoped<IPersonReadRepository, PersonReadRepository>();
            collection.AddScoped<IProductService, ProductService>();
            collection.AddScoped<IPersonService, PersonService>();
        }
    }
}

