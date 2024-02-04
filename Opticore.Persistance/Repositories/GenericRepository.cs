using Microsoft.EntityFrameworkCore;
using Opticore.Persistence.DatabaseContext;
using OptiCore.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opticore.Persistence.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly OptiCoreDbContext _context;
        public GenericRepository(OptiCoreDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByCodeAsync(string code)
        {
            return await _context.Set<T>().FindAsync(code);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await (_context.Set<T>().FindAsync(id));
        }

        public async Task UpdateAsync(T entity)
        {

            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();   
        }
    }
}
