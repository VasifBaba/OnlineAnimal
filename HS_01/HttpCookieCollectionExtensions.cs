using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HS_01
{
    public static class HttpCookieCollectionExtensions
    {
        public static string Language(this HttpCookieCollection cook)
        {
            return cook["Language"]?.Value;
        }
    }
}