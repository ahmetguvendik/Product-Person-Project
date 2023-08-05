using System;
using Application.Services;
using Application.ViewModels;
using Persistance.Contexts;

namespace Persistance.Services
{
	public class PersonService : IPersonService
	{
        private readonly ProductDbContext _context;
        public PersonService(ProductDbContext context)
		{
            _context = context;
		}

        public IQueryable<VM_Person_Product> GetPersonProduct()
        {
            var model = from p in _context.People
                        join product in _context.Products
            on p.ProductId equals product.Id
                        select new VM_Person_Product
                        {
                            Name = p.Name,
                            Surname = p.Surname,
                            Info = p.Info,
                            ProductName = product.Name,
                        };

            return model;
        }
    }
}

