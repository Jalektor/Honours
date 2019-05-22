using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.Web.Models.Checkout
{
    public class CheckoutItemsRepository
    {
        public List<CheckoutHelper> customerCheckoutBasket { get; set; }
        public decimal TotalPrice { get; set; }

        public void CreateTotal()
        {
            foreach (var item in customerCheckoutBasket)
            {
                TotalPrice += item.ItemPriceTotal;
            }
            decimal.Round(TotalPrice, 2);
        }
    }
}
