using Microsoft.EntityFrameworkCore;
using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Domain.Inventory;

namespace Opticore.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OptiCoreDbContext context) : base(context)
        {
        }

        public async Task<bool> IsProductUnique(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name == name);
        }
    }
}