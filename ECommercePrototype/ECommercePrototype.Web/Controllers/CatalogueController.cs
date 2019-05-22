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
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommercePrototype.Web.Models.APIConnections;

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
        public async Task<IActionResult> Index(string catalogueBrand, string searchString, string catalogueType)
        {
            string url = "api/catalogue";
            CatalogueItemRepository ItemRepo = new CatalogueItemRepository();

            HttpClient client = _catalogueAPI.CreateClient();

            HttpResponseMessage response = await client.GetAsync(url);

            // checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                ItemRepo.catalogue = JsonConvert.DeserializeObject<List<CatalogueHelper>>(result);
            }

            var brands = from m in ItemRepo.catalogue
                         select m.ItemBrand;

            var searchItem = from m in ItemRepo.catalogue
                             select m;

            var types = from m in ItemRepo.catalogue
                         select m.ItemType;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchItem = searchItem.Where(s => s.ItemName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(catalogueBrand))
            {
                searchItem = searchItem.Where(x => x.ItemBrand.Contains(catalogueBrand));
            }

            if (!string.IsNullOrEmpty(catalogueType))
            {
                searchItem = searchItem.Where(x => x.ItemType.Contains(catalogueType));
            }

            ItemRepo.catalogueBrands = new SelectList(brands.Distinct().ToList());
            ItemRepo.catalogueTypes = new SelectList(types.Distinct().ToList());

            ItemRepo.catalogue = searchItem.ToList();

            return View(ItemRepo);
        }

        // GET: CatalogueItem by ID
        public async Task<IActionResult> Details(int? id)
        {
            string url = $"api/catalogue/{id}";
            CatalogueHelper catalogueItem = new CatalogueHelper();

            HttpClient client = _catalogueAPI.CreateClient();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                catalogueItem = response.Content.ReadAsAsync<CatalogueHelper>().Result;
            }

            ViewBag.CatalogueItemPic = "~/images/" + catalogueItem.Pic;

            catalogueItem.GetQuantity();

            return View(catalogueItem);
        }

    }

}