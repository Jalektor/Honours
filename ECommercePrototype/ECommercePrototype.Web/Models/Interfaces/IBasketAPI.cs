using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommercePrototype.Web.Models.Interfaces
{
    public interface IBasketAPI
    {
        HttpClient CreateClient();
    }
}
