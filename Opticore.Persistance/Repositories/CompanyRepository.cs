using Microsoft.EntityFrameworkCore;
using Opticore.Persistence.DatabaseContext;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Domain.Companies;

namespace Opticore.Persistence.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(OptiCoreDbContext context) : base(context) { }

        public async Task AddLinkedCompany(int companyId, int linkedCompanyId)
        {
            var company = await GetByIdAsync(companyId);
            var linkedCompany = await GetByIdAsync(linkedCompanyId);
            if (company == null || linkedCompany == null)
            {
                throw new NotFoundException("","");
            }

            company.AddLinkedCompany(linkedCompany);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Company>> GetLinkedCompanies(int companyId)
        {
            var company = await _context.Companies
                .Include(c => c.LinkedCompanies)
                .FirstOrDefaultAsync(c => c.Id == companyId);

            return company?.LinkedCompanies.ToList() ?? new List<Company>();
        }
    }
}
