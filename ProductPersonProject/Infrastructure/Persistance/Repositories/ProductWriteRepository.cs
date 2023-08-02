using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class ProductWriteRepository : WriteRepository<Product>,IProductWriteRepository
	{
		public ProductWriteRepository(ProductDbContext context) : base(context)
        {

		}
	}
}

