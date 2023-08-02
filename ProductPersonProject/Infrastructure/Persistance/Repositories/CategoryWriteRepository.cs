﻿using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
	{
		public CategoryWriteRepository(ProductDbContext context) : base(context)
        {
		}
	}
}

