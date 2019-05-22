using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.API.Basket.Models.Repository
{
    public interface IDataRepository
    {
        IEnumerable<BasketItem> GetAll();
        long Add(BasketItem basketItem);
        void Edit(BasketItem basketItem);
        void Remove(int id);

    }
}
