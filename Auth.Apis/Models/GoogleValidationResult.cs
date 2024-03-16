using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Models
{
    public class GoogleValidationResult
    {
        public bool Validated => Data != null && Exception == null;
        public GoogleJsonWebSignature.Payload? Data { get; init; }
        public InvalidJwtException? Exception { get; init; }

        public static GoogleValidationResult Success(GoogleJsonWebSignature.Payload data) => new GoogleValidationResult() { Data = data };
        public static GoogleValidationResult Error(InvalidJwtException exception) => new GoogleValidationResult() { Exception = exception };
    }
}
