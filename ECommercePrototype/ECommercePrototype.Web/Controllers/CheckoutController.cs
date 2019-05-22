using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ECommercePrototype.Web.Models.Basket;
using ECommercePrototype.Web.Models.Checkout;
using ECommercePrototype.Web.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommercePrototype.Web.Controllers
{
    public class CheckoutController : Controller
    {
        readonly ICheckoutAPI _checkoutAPI;

        public CheckoutController(ICheckoutAPI checkoutAPI)
        {
            _checkoutAPI = checkoutAPI;
        }
        // GET: Checkout
        public async Task<IActionResult> Index()
        {
            string url = "api/checkout";
            CheckoutItemsRepository checkoutItems = new CheckoutItemsRepository();

            HttpClient client = _checkoutAPI.CreateClient();

            HttpResponseMessage response = await client.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                checkoutItems.customerCheckoutBasket = JsonConvert.DeserializeObject<List<CheckoutHelper>>(result);
            }

            checkoutItems.CreateTotal();

            return View(checkoutItems);
        }

        // GET: Checkout/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Checkout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Checkout/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PurchaseItems([Bind("CatalogueItemID", "ItemName", "ItemDescription", "ItemPrice", "ItemBrand", "ItemType", "Pic", "Quantity")] List<BasketHelper> _customerBasket)
        {
            string url = "api/checkout";
            HttpClient client = _checkoutAPI.CreateClient();
            try
            {
                // TODO: Add insert logic here
                var item = new StringContent(JsonConvert.SerializeObject(_customerBasket), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, item).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Checkout/Edit/5
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

        // GET: Checkout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Checkout/Delete/5
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