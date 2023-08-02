using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class PersonReadRepository : ReadRepositoryy<Person>,IPersonReadRepository
	{
		public PersonReadRepository(ProductDbContext context) : base(context)
        {
		}
	}
}

