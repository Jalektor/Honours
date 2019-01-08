using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePrototype.Api.Catalogue.Models.Repository
{
    public interface IDataRepository
    {
        IEnumerable<Catalogue> Getall();
        Catalogue Get(int id);
    }
}
