﻿using OptiCore.Domain.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Abstractions.Messaging
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<bool> IsAgentUnique(string name);
    }
}
