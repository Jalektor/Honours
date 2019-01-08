using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommercePrototype.Api.Catalogue.Models.Repository;

namespace ECommercePrototype.Api.Catalogue.Models.DataManager
{
    public class CatalogueManager : IDataRepository
    {
        private readonly CatalogueDBContext context;

        public CatalogueManager(CatalogueDBContext ctx)
        {
            context = ctx;
        }

        public Catalogue Get(int id)
        {
            var catalogue = context.Catalogue.FirstOrDefault(b => b.ItemID == id);
            return catalogue;
        }

        public IEnumerable<Catalogue> Getall()
        {
            var catalogue = context.Catalogue.ToList();
            return catalogue;
        }
    }
}
