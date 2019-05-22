using ECommercePrototype.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ECommercePrototype.Web.Models.APIConnections
{
    public class CheckoutAPI : ICheckoutAPI
    {
        static HttpClient client = new HttpClient();

        private static string _apiBaseURI = "https://localhost:44320";

        public HttpClient CreateClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_apiBaseURI);

            client.DefaultRequestHeaders.Clear();

            // Define request Data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
