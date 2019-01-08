using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using ECommercePrototype.Web.Models;
using System.Net.Http.Headers;
using System.Net;
using ECommercePrototype.Web.Models.Interfaces;
using ECommercePrototype.Web.Models.Catalogue;

namespace ECommercePrototype.WebFrontEnd.Controllers
{
    public class CatalogueController : Controller
    {
        readonly ICatalogueAPI _catalogueAPI;

        public CatalogueController(ICatalogueAPI catalogueAPI)
        {
            _catalogueAPI = catalogueAPI;
        }

        // GET: Catalogue
        public async Task<IActionResult> Index()
        {
            string url = "api/catalogue";
            CatalogueItemRepository ItemRepo = new CatalogueItemRepository();

            HttpClient client = _catalogueAPI.CreateClient();

            HttpResponseMessage response = await client.GetAsync(url);
            
            // checking the response is successful or not which is sent using HttpClient
            if(response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                ItemRepo.catalogue = JsonConvert.DeserializeObject<List<CatalogueHelper>>(result);
            }

            return View(ItemRepo.catalogue);
        }

        // GET: CatalogueItem by ID
        public async Task<IActionResult> Details(int? id)
        {          
            string url = "api/catalogue/" + id.ToString();
            CatalogueHelper catalogueItem = new CatalogueHelper();

            HttpClient client = _catalogueAPI.CreateClient();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                catalogueItem = response.Content.ReadAsAsync<CatalogueHelper>().Result;
            }

            ViewBag.CatalogueItemPic = "~/images/" + catalogueItem.Pic;

            return View(catalogueItem);
        }

    }

}