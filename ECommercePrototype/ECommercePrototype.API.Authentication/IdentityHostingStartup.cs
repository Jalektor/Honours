using ECommercePrototype.API.Authentication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//[assembly: HostingStartup(typeof(ECommercePrototype.API.Authentication.IdentityHostingStartup))]
namespace ECommercePrototype.API.Authentication
{
    public class IdentityHostingStartup/* : IHostingStartup*/
    {
        //public void Configure(IWebHostBuilder builder)
        //{
        //    builder.ConfigureServices((context, services) => {
        //        services.AddDbContext<AuthenticateDBContext>(options =>
        //            options.UseSqlServer(
        //                context.Configuration.GetConnectionString("ECommerceAuthenticate")));

        //        services.AddDefaultIdentity<IdentityUser>()
        //            .AddEntityFrameworkStores<AuthenticateDBContext>();
        //    });
        //}
    }
}
