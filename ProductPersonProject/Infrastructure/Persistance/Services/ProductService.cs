using System;
using Application.Services;
using Application.ViewModels;
using Persistance.Contexts;

namespace Persistance.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;
        public ProductService(ProductDbContext context)
        {
            _context = context;
        }

        public IQueryable<VM_Product_Category> GetProductCategory()
        {
            var model = from p in _context.Products
                        join c in _context.Categories
            on p.CategoryId equals c.Id
                        select new VM_Product_Category
                        {
                            Id = p.Id,
                           Name = p.Name,
                           Info = p.Info,
                           SeriNo = p.SeriNo,
                           Verildimi =p.Verildimi,
                           CategoryName = c.Name
                        };

            return model;
        }
    }
}

