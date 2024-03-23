using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Models
{
    public class JwkResponse
    {
        public JsonWebKey[] Keys { get; set; }
    }
}
