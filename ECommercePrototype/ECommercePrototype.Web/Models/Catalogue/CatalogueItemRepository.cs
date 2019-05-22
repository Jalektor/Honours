using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.Web.Models.Catalogue
{
    public class CatalogueItemRepository
    {
        public List<CatalogueHelper> catalogue { get; set; }
        public SelectList catalogueBrands;
        public SelectList catalogueTypes;

        public string catalogueBrand { get; set; }
        public string catalogueType { get; set; }
    }
}
