using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.API.Checkout.Models
{
    public class CheckoutItemsRepository
    {
        public List<CheckoutItem> customerCheckoutBasket { get; set; }
        public decimal TotalPrice { get; set; }

        public void AddUpPrices()
        {
            for(int i = 0; i < customerCheckoutBasket.Count(); i++)
            {
                TotalPrice += customerCheckoutBasket[i].ItemPriceTotal;
            }
        }
    }
}
