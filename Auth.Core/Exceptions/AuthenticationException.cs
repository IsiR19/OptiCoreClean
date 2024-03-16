using Auth.Core.Enums;
using Google.Apis.Auth;

namespace Auth.Core.Exceptions
{
    public class AuthenticationException : Exception
    {
        #region Private Fields

        private string? _additionInfo;
        private string? _manualMessage;

        #endregion Private Fields

        #region Public Properties

        public AuthenticationExceptionCause Cause { get; init; }
        public override string Message => GenerateMessage();

        #endregion Public Properties

        #region Public Constructors

        public AuthenticationException()
        { }

        public AuthenticationException(InvalidJwtException exception)
        {
            Cause = AuthenticationExceptionCause.Token;
            _additionInfo = exception.Message;
        }

        public AuthenticationException(AuthenticationExceptionCause cause, string message)
        {
            Cause = cause;
            _manualMessage = message;
        }

        #endregion Public Constructors

        #region Public Methods

        public static AuthenticationException NotRegistered(string email)
            => new AuthenticationException()
            {
                Cause = AuthenticationExceptionCause.NotRegistered,
                _additionInfo = email
            };

        public static AuthenticationException Token(InvalidJwtException invalidJwtException) => new AuthenticationException(invalidJwtException);

        public static AuthenticationException Token(string message)
            => new AuthenticationException
            {
                Cause = AuthenticationExceptionCause.Token,
                _additionInfo = message
            };

        #endregion Public Methods

        #region Private Methods

        private string GenerateMessage()
        {
            if (!string.IsNullOrWhiteSpace(_manualMessage))
            {
                return _manualMessage;
            }
            switch (Cause)
            {
                case AuthenticationExceptionCause.Token:
                    return $"Token failed to validate: {_additionInfo}";

                case AuthenticationExceptionCause.NotRegistered:
                    return $"User {_additionInfo} was not found";

                default:
                    return "Failed to authenticated";
            }
        }

        #endregion Private Methods
    }
}