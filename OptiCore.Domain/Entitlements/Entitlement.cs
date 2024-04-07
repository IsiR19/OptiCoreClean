using Auth.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Entitlements
{
    public class Entitlement : IEntitlement
    {
        public Entitlement() { }
        public Entitlement(int id, string name, string description, string code)
        {
            Id = id;
            Name = name;
            Description = description;
            Code = code;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
