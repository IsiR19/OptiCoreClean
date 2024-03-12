using OptiCore.Domain.HeadOffices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IHeadOfficeRepository :IRepository<HeadOffice>
    {
        Task<bool> IsHeadOfficeUnique(string registrationNumber);
    }
}
