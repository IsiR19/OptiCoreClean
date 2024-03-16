using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Models.Requests
{
    public class LoginRequest
    {
        /// <summary>
        /// The Id token supplied from Google's sign-in
        /// </summary>
        public required string GoogleIdToken { get; init; }

        /// <summary>
        /// The IP Address that has requested the log in
        /// </summary>
        public required string IpAddress { get; init; }
    }
}
