using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ECommercePrototype.Web.Models.Authentication;
using ECommercePrototype.Web.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommercePrototype.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        readonly IAuthenticateAPI _authenticateAPI;

        public AuthenticationController(IAuthenticateAPI authenticateAPI)
        {
            _authenticateAPI = authenticateAPI;
        }
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string password)
        {
                IdentityHelper identity = new IdentityHelper
                {
                    Email = email,
                    Password = password,
                    ConfirmPassword = password
                };
                string url = "api/authenticate";

                HttpClient client = _authenticateAPI.CreateClient();

                var item = new StringContent(JsonConvert.SerializeObject(identity), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(url, item).Result;
            if(response.IsSuccessStatusCode)
            {
                return View("Index", "Catalogue");
            }
            return View();
        }

        //// GET: Authentication/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Authentication/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}