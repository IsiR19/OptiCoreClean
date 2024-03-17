using OptiCore.Domain.HeadOffices;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IHeadOfficeRepository : IRepository<HeadOffice>
    {
        Task<bool> IsHeadOfficeUnique(string registrationNumber);
    }
}