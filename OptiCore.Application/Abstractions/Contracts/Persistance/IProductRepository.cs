using OptiCore.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> IsProductUnique(string name);
    }
}
