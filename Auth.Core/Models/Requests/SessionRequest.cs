using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Models.Requests
{
    public class SessionRequest
    {
        public string SessionGuid { get; init; }
        public string IpAddress { get; set; }
    }
}
