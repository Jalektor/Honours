using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECommercePrototype.Api.Catalogue.Models
{
    public class CatalogueDBContext : DbContext
    {
        public CatalogueDBContext()
        {
        }
        public CatalogueDBContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<Catalogue> Catalogue { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
