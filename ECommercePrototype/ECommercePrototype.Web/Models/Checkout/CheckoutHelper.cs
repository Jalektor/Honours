using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.Web.Models.Checkout
{
    public class CheckoutHelper
    {
        public CheckoutHelper()
        {

        }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemBrand { get; set; }
        public string ItemType { get; set; }
        public string Pic { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPriceTotal { get; set; }
           
        
    }
}
