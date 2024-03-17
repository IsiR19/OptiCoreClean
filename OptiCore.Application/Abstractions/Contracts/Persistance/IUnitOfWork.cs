namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        Task<bool> SaveEntitiesAsync();
    }
}