using Microsoft.EntityFrameworkCore;
using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Domain.HeadOffices;

namespace Opticore.Persistance.Repositories
{
    public class HeadOfficeRepository : GenericRepository<HeadOffice>, IHeadOfficeRepository
    {
        public HeadOfficeRepository(OptiCoreDbContext context) : base(context)
        {
        }

        public async Task<bool> IsHeadOfficeUnique(string registrationNumber)
        {
            return await _context.HeadOffices.AnyAsync(p => p.RegistrationNumber == registrationNumber) == false;
        }
    }
}