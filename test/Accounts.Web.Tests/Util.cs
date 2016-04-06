using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Accounts.Web.Tests
{
    public static class Extentions
    {
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, string requestUri, object obj)
        {
            client.BaseAddress = new Uri(requestUri);
            return null;
        }
    }
}
