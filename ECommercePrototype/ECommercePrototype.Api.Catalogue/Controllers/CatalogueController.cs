using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommercePrototype.Api.Catalogue.Models;
using ECommercePrototype.Api.Catalogue.Models.Repository;
using ECommercePrototype.Api.Catalogue.Models.DataManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommercePrototype.Api.Catalogue.Controllers
{
    [Route("api/[controller]")]
    public class CatalogueController : Controller
    {

        private readonly IDataRepository _iRepo;

        public CatalogueController(IDataRepository repo)
        {
            _iRepo = repo;
        }

        // GET: api/catalogue
        [HttpGet]
        public IEnumerable<Models.Catalogue> Getall()
        {
            return _iRepo.Getall().ToList();
        }

        //GET api/catalogue/5
        [HttpGet("{id}")]
        public Models.Catalogue GetCatalogueItem(int id)
        {
            return _iRepo.Get(id);
        }
    }
}
