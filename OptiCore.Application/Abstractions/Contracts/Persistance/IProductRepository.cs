using OptiCore.Domain.Inventory;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> IsProductUnique(string name);
    }
}