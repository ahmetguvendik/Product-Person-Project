using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class PersonWriteRepository : WriteRepository<Person>, IPersonWriteRepository
	{
		public PersonWriteRepository(ProductDbContext context) : base(context)
        {
		}
	}
}

