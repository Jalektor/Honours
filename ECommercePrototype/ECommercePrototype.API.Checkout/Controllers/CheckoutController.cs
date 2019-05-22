using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommercePrototype.API.Checkout.Models;

namespace ECommercePrototype.API.Checkout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutDBContext _context;

        public CheckoutController(CheckoutDBContext context)
        {
            _context = context;
        }

        // GET: api/Checkout
        [HttpGet]
        public IEnumerable<CheckoutItem> GetCheckoutItem()
        {
            return _context.CheckoutItem.ToList();
        }

        //// GET: api/Checkout/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCheckoutItem([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var checkoutItem = await _context.CheckoutItem.FindAsync(id);

        //    if (checkoutItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(checkoutItem);
        //}

        // POST: api/Checkout
        [HttpPost]
        public void Post([FromBody] List<BasketHelper> customerBasket)
        {
            _context.CheckoutItem.RemoveRange(_context.CheckoutItem);
            for (int i = 0; i < customerBasket.Count(); i++)
            {
                CheckoutItem _checkoutItem = new CheckoutItem
                {
                    ItemName = customerBasket[i].ItemName,
                    ItemPrice = customerBasket[i].ItemPrice,
                    ItemBrand = customerBasket[i].ItemBrand,
                    ItemType = customerBasket[i].ItemType,
                    Pic = customerBasket[i].Pic,
                    Quantity = customerBasket[i].Quantity
                };
                if (_checkoutItem.Quantity > 1)
                {
                    _checkoutItem.ItemPriceTotal = _checkoutItem.ItemPrice * _checkoutItem.Quantity;
                }
                else
                {
                    _checkoutItem.ItemPriceTotal = _checkoutItem.ItemPrice;
                }
                decimal.Round(_checkoutItem.ItemPriceTotal, 2);
                _context.CheckoutItem.Add(_checkoutItem);
                _context.SaveChanges();

            }           
        }

        private bool CheckoutItemExists(int id)
        {
            return _context.CheckoutItem.Any(e => e.checkoutItem == id);
        }
    }
}