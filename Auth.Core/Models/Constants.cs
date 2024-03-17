using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core
{
    public static class Constants
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
    }
}
