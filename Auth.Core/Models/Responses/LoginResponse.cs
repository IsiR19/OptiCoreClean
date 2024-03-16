using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Models.Responses
{
    public class LoginResponse
    {
        #region Public Properties

        /// <summary>
        /// The <seealso cref="DateTime"/> of the session Id's expiration
        /// </summary>
        public DateTime Expirey { get; init; }

        /// <summary>
        /// The session Id for the currently logged in user
        /// </summary>
        public string SessionId { get; init; }

        /// <summary>
        /// The user's UUID
        /// </summary>
        public string UserUID { get; init; }

        #endregion Public Properties

        #region Public Constructors

        public LoginResponse()
        { }

        public LoginResponse(string sessionId, DateTime expirey, string userUID)
        {
            SessionId = sessionId;
            Expirey = expirey;
            UserUID = userUID;
        }

        #endregion Public Constructors
    }
}