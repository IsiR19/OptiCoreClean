using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core
{
    public static partial class Constants
    {
        public static class Cookies
        {
            public const string Session = "x-session-id";
        }
        public static class Policies
        {
            public const string None = "NONE";
        }
        public static class HttpContextItems
        {
            public const string SessionGuid = Cookies.Session;
            public const string userUID = "x-uuid";
        }
        public static partial class ConfigurationKeys
        {
            public static partial class AppSettings
            {
                public static class Firebase
                {
                    public const string ProjectId = "firebaseProjectId";

                    #region Main API
                    public const string ApiKey = "firebaseApiKey";
                    public const string AuthDomain = "firebaseAuthDomain";
                    public const string StorageBucket = "firebaseStorageBucket";
                    public const string MessagingSenderId = "firebaseMessagingSenderId";
                    public const string AppId = "firebaseAppId";
                    public const string MeasurementId = "firebaseMeasurementId";
                    #endregion


                    #region OAuth
                    public const string ClientId = "firebaseClientId";
                    public const string AuthUri = "firebaseAuthUri";
                    public const string TokenUri = "firebaseTokenUri";
                    public const string JwksUris = "firebaseJwksUris";
                    public const string ClientSecret = "firebaseClientSecret";
                    public const string Issuer = "firebaseIssuer";
                    #endregion
                }
            }
            public static partial class Environment
            {
                public static class Firebase
                {
                    public const string ProjectId = "FIREBASE_PROJECT_ID";

                    #region Main API
                    public const string ApiKey = "FIREBASE_API_KEY";
                    public const string AuthDomain = "FIREBASE_AUTH_DOMAIN";
                    public const string StorageBucket = "FIREBASE_STORAGE_BUCKET";
                    public const string MessagingSenderId = "FIREBASE_MESSAGING_SENDER_ID";
                    public const string AppId = "FIRE_BASE_APP_ID";
                    public const string MeasurementId = "FIREBASE_MEASUREMENT_ID";
                    #endregion
                    #region OAuth
                    public const string ClientId = "FIREBASE_CLIENT_ID";
                    public const string AuthUri = "FIREBASE_AUTH_URI";
                    public const string TokenUri = "FIREBASE_TOKEN_URI";
                    public const string JwksUris = "FIREBASE_JWKS_URIS";
                    public const string ClientSecret = "FIREBASE_CLIENT_SECRET";
                    public const string Issuer = "FIREBASE_ISSUER";
                    #endregion
                }
            }
        }
        public static class TokenClaims
        {
            public const string Name = "name";
            public const string Issuer = "iss";
            public const string Audience = "aud";
            public const string Subject = "sub";
            public const string IssuedAt = "iat";
            public const string ExpiresAt = "exp";
            public const string Email = "email";
            public const string EmailVerified = "email_verified";
        }
        public static class UserResolver
        {
            public const string System = "System";
        }
    }
}
