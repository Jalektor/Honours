using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommercePrototype.Web.Models.Interfaces;
using ECommercePrototype.Web.Models.Basket;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using ECommercePrototype.Web.Controllers;
using ECommercePrototype.Web.Models.APIConnections;
using ECommercePrototype.Web.Models.Catalogue;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommercePrototype.Web.Controllers
{
    public class BasketController : Controller
    {
        readonly IBasketAPI _basketAPI;

        public BasketController(IBasketAPI basketApi)
        {
            _basketAPI = basketApi;
        }
        // GET: Basket
        public async Task<IActionResult> Index()
        {
            ViewBag.AvailQuantity = new List<SelectListItem>
            {
                new SelectListItem { Text = "1", Value = "1"},
                new SelectListItem { Text = "2", Value = "2"},
                new SelectListItem { Text = "3", Value = "3"}
            };

            string url = "api/basket";

            BasketItemRepository BasketRepo = new BasketItemRepository();

            HttpClient client = _basketAPI.CreateClient();

            HttpResponseMessage response = await client.GetAsync(url);

            // checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                BasketRepo.customerBasket = JsonConvert.DeserializeObject<List<BasketHelper>>(result);
            }
            if(BasketRepo.customerBasket != null)
            {
                var custBasket = BasketRepo.customerBasket;
                return View(custBasket);
            }
            else
            {
                return View();
            }
        }

        // GET: Basket/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Basket/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Basket/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddItemToBasket([Bind("ItemID", "ItemName", "ItemDescription", "ItemPrice", "ItemAvailableStock", "ItemBrand", "ItemType", "Pic")]CatalogueHelper _basketItem)
        {
            string url = "api/basket";
            HttpClient client = _basketAPI.CreateClient();

            BasketHelper basketItem = new BasketHelper
            {
                CatalogueItemID = _basketItem.ItemID,
                ItemName = _basketItem.ItemName,
                ItemDescription = _basketItem.ItemDescription,
                ItemPrice = _basketItem.ItemPrice,
                ItemBrand = _basketItem.ItemBrand,
                ItemType = _basketItem.ItemType,
                Pic = _basketItem.Pic,
                Quantity = 1
        };

            var item = new StringContent(JsonConvert.SerializeObject(basketItem), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, item).Result;        

            return RedirectToAction("Index", "Basket");
        }

        //// GET: Basket/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Basket/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult UpdateBasket(int id, int quantity)
        {
            try
            {
                string url = $"api/basket/{id}";
                HttpClient client = _basketAPI.CreateClient();
                var item = new StringContent(quantity.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url, item).Result;
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Basket");
                }
                else
                {
                    return NotFound();
                }
                // TODO: Add update logic here

            }
            catch
            {
                return View();
            }
        }

        //// GET: Basket/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Basket/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteItemFromBasket(int? id)
        {
            try
            {
                string url = $"api/basket/{id}";
                HttpClient client = _basketAPI.CreateClient();

                HttpResponseMessage response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Basket");
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }
        }
    }
}