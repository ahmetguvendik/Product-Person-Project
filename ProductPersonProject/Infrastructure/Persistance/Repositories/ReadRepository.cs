using System;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class ReadRepositoryy<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ProductDbContext _context;
        public ReadRepositoryy(ProductDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public async Task<T> GetById(string id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

