using ECommercePrototype.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ECommercePrototype.Web.Models.APIConnections
{
    public class AuthenticateAPI : IAuthenticateAPI
    {
        static HttpClient client = new HttpClient();

        private static string _apiBaseUri = "https://localhost:44382/";
        public HttpClient CreateClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_apiBaseUri);

            client.DefaultRequestHeaders.Clear();

            // Define request Data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
