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

        public BasketItem Add(BasketItem basketItem)
        {
            var addedItem = context.Basket.Add(basketItem);
            context.SaveChanges();
            throw new NotImplementedException();
        }

        public BasketItem Edit(BasketItem basketItem)
        {
            var editedItem = context.Basket.Update(basketItem);
            throw new NotImplementedException();
        }

        public IEnumerable<BasketItem> GetAll()
        {
            var customerBasket = context.Basket.ToList();

            return customerBasket;
        }

        public BasketItem Remove(BasketItem basketItem)
        {
            var removedItem = context.Basket.Remove(basketItem);
            throw new NotImplementedException();
        }
    }
}
