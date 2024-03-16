using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Models.Responses
{
    public class LoginResponse
    {
        /// <summary>
        /// The session Id for the currently logged in user
        /// </summary>
        public required string SessionId { get; init; }

        /// <summary>
        /// The <seealso cref="DateTime"/> of the session Id's expiration
        /// </summary>
        public required DateTime Expirey { get; init; }
    }
}
