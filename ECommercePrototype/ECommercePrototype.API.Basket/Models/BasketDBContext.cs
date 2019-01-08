using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECommercePrototype.API.Basket.Models
{
    public class BasketDBContext : DbContext
    {
        public BasketDBContext()
        {

        }
        public BasketDBContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<BasketItem> Basket { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
