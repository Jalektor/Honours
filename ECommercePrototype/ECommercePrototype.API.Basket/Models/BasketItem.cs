using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.API.Basket.Models
{
    public class BasketItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int basketItem { get; set; }
        public int CatalogueItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemBrand { get; set; }
        public string ItemType { get; set; }
        public string Pic { get; set; }
        public int Quantity { get; set; }
    }
}
