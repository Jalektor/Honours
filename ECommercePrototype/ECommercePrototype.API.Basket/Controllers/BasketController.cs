using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommercePrototype.API.Basket.Models;
using ECommercePrototype.API.Basket.Models.DataManager;
using ECommercePrototype.API.Basket.Models.Repository;

namespace ECommercePrototype.API.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IDataRepository _iRepo;

        public BasketController(IDataRepository repo)
        {
            _iRepo = repo;
        }
        // GET: api/Basket
        [HttpGet]
        public IEnumerable<BasketItem> Getall()
        {
            return _iRepo.GetAll().ToList();
        }

        // GET: api/Basket/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Basket
        [HttpPost]
        public void Post([FromBody] BasketItem _basketItem)
        {
            bool containsItem = false;
            List<BasketItem> basket = _iRepo.GetAll().ToList();
            foreach(var item in basket)
            {
                if(item.CatalogueItemID == _basketItem.CatalogueItemID)
                {
                    //int index = basket.IndexOf(item);
                    //basket[index].Quantity++;
                    item.Quantity++;
                    _iRepo.Edit(item);
                    containsItem = true;
                    break;
                }
            }
            if(containsItem == false)
            {
                _iRepo.Add(_basketItem);
            }
        }

        // PUT: api/Basket/5
        //[Route("api/[controller]/[id]/[quantity]")]
        [HttpPut]
        public void Put(int id, int quantity)
        {
            List<BasketItem> basket = _iRepo.GetAll().ToList();
            foreach (var item in basket)
            {
                if (item.CatalogueItemID == id)
                {
                    item.Quantity = quantity;
                    _iRepo.Edit(item);
                    break;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _iRepo.Remove(id);
        }
    }
}
