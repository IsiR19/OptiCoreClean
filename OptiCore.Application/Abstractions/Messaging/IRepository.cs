using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Abstractions.Messaging 
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByCodeAsync(string code);
        Task<TEntity> CreateAsync(TEntity entity);

    }
}
