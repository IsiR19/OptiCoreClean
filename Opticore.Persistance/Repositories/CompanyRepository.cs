using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opticore.Persistance.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(OptiCoreDbContext context) : base(context) { }

        public async Task<IEnumerable<Company>> GetRelatedCompaniesAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), userId);
            }

            var company = await _context.Companies.FindAsync(user.CompanyId);
            if (company == null)
            {
                throw new NotFoundException(nameof(company), user.CompanyId);
            }

            var relatedCompanies = new List<Company>();
            await GetSubordinatesAsync(company, relatedCompanies);

            return relatedCompanies;
        }

        private async Task GetSubordinatesAsync(Company company, List<Company> relatedUsers)
        {
            // Include the user's subordinates in the related users list
            var subordinates = _context.CompanyHierarchy
                .Where(uh => uh.ParentUserId == company.Id)
                .Select(uh => uh.ChildCompany);

            foreach (var subordinate in subordinates)
            {
                relatedUsers.Add(subordinate);
                await GetSubordinatesAsync(subordinate, relatedUsers);
            }
        }
    }
}
