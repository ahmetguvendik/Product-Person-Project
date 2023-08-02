using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class ProductReadRepository : ReadRepositoryy<Product>, IProductReadRepository
	{
		public ProductReadRepository(ProductDbContext context) : base(context)
        {
		}
	}
}

