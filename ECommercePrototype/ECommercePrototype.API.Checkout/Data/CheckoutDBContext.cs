using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECommercePrototype.API.Checkout.Models
{
    public class CheckoutDBContext : DbContext
    {
        public CheckoutDBContext (DbContextOptions<CheckoutDBContext> options)
            : base(options)
        {
        }

        public DbSet<CheckoutItem> CheckoutItem { get; set; }
    }
}
