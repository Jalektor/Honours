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
            string url = "";
            BasketItemRepository BasketRepo = new BasketItemRepository();

            HttpClient client = _basketAPI.CreatClient();

            HttpResponseMessage response = await client.GetAsync(url);

            // checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                BasketRepo.customerBasket = JsonConvert.DeserializeObject<List<BasketHelper>>(result);
            }

            return View(BasketRepo.customerBasket);
        }

        // GET: Basket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Basket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Basket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItemToBasket(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Basket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Basket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Basket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Basket/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}