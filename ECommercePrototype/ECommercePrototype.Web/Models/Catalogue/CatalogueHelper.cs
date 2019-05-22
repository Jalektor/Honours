using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.Web.Models.Catalogue
{
    public class CatalogueHelper
    {
        public CatalogueHelper()
        {

        }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemAvailableStock { get; set; }
        public string ItemBrand { get; set; }
        public string ItemType { get; set; }
        public string Pic { get; set; }
        public string SelectedQuantity { get; set; }
        public List<SelectListItem> QuantitySelectable { get; set; }

        public void GetQuantity()
        {
            QuantitySelectable = new List<SelectListItem>();
            for (int i = 1; i <= ItemAvailableStock; i++)
            {
                var item = new SelectListItem { Text = i.ToString() };
                QuantitySelectable.Add(item);
            }
        }
    }
}
