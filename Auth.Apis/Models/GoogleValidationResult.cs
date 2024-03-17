using Google.Apis.Auth;

namespace Auth.DomainLogic.Models
{
    public class GoogleValidationResult
    {
        #region Public Properties

        public GoogleJsonWebSignature.Payload? Data { get; init; }
        public InvalidJwtException? Exception { get; init; }
        public bool Validated => Data != null && Exception == null;

        #endregion Public Properties

        #region Public Methods

        public static GoogleValidationResult Error(InvalidJwtException exception) => new GoogleValidationResult() { Exception = exception };

        public static GoogleValidationResult Success(GoogleJsonWebSignature.Payload data) => new GoogleValidationResult() { Data = data };

        #endregion Public Methods
    }
}