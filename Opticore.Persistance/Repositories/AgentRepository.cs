﻿using Microsoft.EntityFrameworkCore;
using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Domain.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opticore.Persistance.Repositories
{
    public class AgentRepository : GenericRepository<Agent>, IAgentRepository
    {
        public AgentRepository(OptiCoreDbContext context) : base(context)
        {
            
        }

        public async Task<bool> IsAgentUnique(string name)
        {
            return await _context.Agents.AnyAsync(a => a.AgentName == name);  
        }

        public async Task<IReadOnlyList<Agent>> GetAgentsByCPId(int cpId)
        {
            return await _context.Agents.Where(a => a.CPId == cpId).ToListAsync();
        }
    }
}
