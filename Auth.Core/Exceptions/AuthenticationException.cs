using Auth.Core.Enums;
using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Exceptions
{
    public class AuthenticationException : Exception
    {
        public override string Message => GenerateMessage();
        private string? _manualMessage;
        private string? _additionInfo;
        public AuthenticationExceptionCause Cause { get; init; }

        public AuthenticationException() { }
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

        public static AuthenticationException Token(InvalidJwtException invalidJwtException) => new AuthenticationException(invalidJwtException);
        public static AuthenticationException Token(string message) 
            => new AuthenticationException
        {
            Cause = AuthenticationExceptionCause.Token,
            _additionInfo = message
        };

        public static AuthenticationException NotRegistered(string email)
            => new AuthenticationException()
            {
                Cause = AuthenticationExceptionCause.NotRegistered,
                _additionInfo = email
            };

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
    }
}
