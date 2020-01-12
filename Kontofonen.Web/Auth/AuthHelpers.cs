using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;

namespace Kontofonen.Web.Auth
{
    public static class AuthHelpers
    {
        public static string GetSpareBank1AuthorizeUrl(Guid clientId, string redirectUri, string state)
        {
            return "https://api.sparebank1.no/oauth/authorize?" +
                   CreateQueryString(new Dictionary<string, object>
                   {
                       {"finInst", "fid-ostlandet"},
                       {"client_id", clientId},
                       {"redirect_uri", redirectUri},
                       {"state", state},
                       {"response_type", "code"}
                   });
        }

        public static string CreateQueryString(IDictionary<string, object> parameters)
        {
            var query = "";
            foreach (var (key, value) in parameters)
            {
                query = QueryHelpers.AddQueryString(
                    query,
                    key,
                    value.ToString()
                );
            }

            return query.Substring(1);
        }
    }
}