using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces
{
    /// <summary>
    /// This service can be used to retrieve basic information about the signed in user
    /// </summary>
    public interface IUserResolver
    {
        string Name { get; }
        string Email { get; }
        string UUID { get; }
        string Session { get; }
    }
}
