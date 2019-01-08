using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.API.Basket.Models.Repository
{
    public interface IDataRepository
    {
        IEnumerable<BasketItem> GetAll();
        BasketItem Add(BasketItem basketItem);
        BasketItem Edit(BasketItem basketItem);
        BasketItem Remove(BasketItem basketItem);

    }
}
