using ECommercePrototype.API.Basket.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.API.Basket.Models.DataManager
{
    public class BasketManager : IDataRepository
    {
        private readonly BasketDBContext context;

        public BasketManager(BasketDBContext ctx)
        {
            context = ctx;
        }

        public long Add(BasketItem basketItem)
        {

            context.Basket.Add(basketItem);
            long basketItemID = context.SaveChanges();
            return basketItemID;
        }

        public void Edit(BasketItem basketItem)
        {
            context.Basket.Update(basketItem);
            context.SaveChanges();
        }

        public IEnumerable<BasketItem> GetAll()
        {
            var customerBasket = context.Basket.ToList();
            return customerBasket;
        }

        public void Remove(int id)
        {
            var basketItem = context.Basket.FirstOrDefault(b => b.CatalogueItemID == id);
            context.Basket.Remove(basketItem);
            context.SaveChanges();
        }
    }
}
