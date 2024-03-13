﻿using Microsoft.EntityFrameworkCore;
using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Domain.Agents;
using OptiCore.Domain.CP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opticore.Persistance.Repositories
{
    public class CpRepository : GenericRepository<Cp>, ICpRepository
    {
        public CpRepository(OptiCoreDbContext context) : base(context)
        {

        }
        public async Task<IReadOnlyList<Cp>> GetCpByHeadOfficeId(int HeadOfficeId)
        {
            return await _context.Cps.Where(c => c.HeadOfficeId == HeadOfficeId).ToListAsync(); 
        }

        public async Task<bool> IsCPUnique(string name)
        {
            return await _context.Cps.AnyAsync(c => c.Name == name);
        }
    }
}
