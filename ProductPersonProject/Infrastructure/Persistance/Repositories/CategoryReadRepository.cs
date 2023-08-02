using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class CategoryReadRepository : ReadRepositoryy<Category>, ICategoryReadRepository
	{
		public CategoryReadRepository(ProductDbContext context) : base(context)
        {
		}
	}
}

