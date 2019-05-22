using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ECommercePrototype.API.Checkout.Models
{
    public class CheckoutItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int checkoutItem { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemBrand { get; set; }
        public string ItemType { get; set; }
        public string Pic { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPriceTotal { get; set; }

    }
}
