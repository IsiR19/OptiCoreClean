using OptiCore.Domain.CP;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface ICpRepository : IRepository<Cp>
    {
        Task<bool> IsCPUnique(string name);

        Task<IReadOnlyList<Cp>> GetCpByHeadOfficeId(int HeadOfficeId);
    }
}