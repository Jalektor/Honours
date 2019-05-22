﻿// <auto-generated />
using ECommercePrototype.API.Checkout.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommercePrototype.API.Checkout.Migrations
{
    [DbContext(typeof(CheckoutDBContext))]
    partial class CheckoutDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommercePrototype.API.Checkout.Models.CheckoutItem", b =>
                {
                    b.Property<int>("checkoutItem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemBrand");

                    b.Property<string>("ItemName");

                    b.Property<decimal>("ItemPrice");

                    b.Property<decimal>("ItemPriceTotal");

                    b.Property<string>("ItemType");

                    b.Property<string>("Pic");

                    b.Property<int>("Quantity");

                    b.HasKey("checkoutItem");

                    b.ToTable("CheckoutItem");
                });
#pragma warning restore 612, 618
        }
    }
}