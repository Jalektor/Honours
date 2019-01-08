using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using ECommercePrototype.Web.Models;
using ECommercePrototype.Web.Models.Interfaces;
using ECommercePrototype.Web.Models.APIConnections;
using ECommercePrototype.Web.Models.Catalogue;

namespace ECommercePrototype.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ICatalogueAPI _catalogueAPI;

        CatalogueItemRepository ItemRepo = new CatalogueItemRepository();


        public HomeController(ICatalogueAPI catalogueAPI)
        {
            _catalogueAPI = catalogueAPI;
        }

        //public async Task<IActionResult> Index()
        //{
        //    HttpClient client = _catalogueAPI.CreateClient();

        //    HttpResponseMessage response = await client.GetAsync("api/catalogue");

        //    //checking the response is successful or not which is sent using HttpClient
        //    if (response.IsSuccessStatusCode)
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            ItemRepo.catalogue = JsonConvert.DeserializeObject<List<CatalogueHelper>>(result);
        //        }

        //    return View(ItemRepo.catalogue);
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
