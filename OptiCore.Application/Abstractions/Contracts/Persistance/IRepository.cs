using OptiCore.Domain.Core;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByCodeAsync(string code);

        Task CreateAsync(TEntity entity);
    }
}