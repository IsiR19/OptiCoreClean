using OptiCore.Domain.Companies;
using OptiCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task AddLinkedCompany(int companyId, int linkedCompanyId);
        Task <List<Company>> GetLinkedCompanies(int companyId);
    }
}
