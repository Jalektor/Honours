﻿// <auto-generated />
using ECommercePrototype.API.Basket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommercePrototype.API.Basket.Migrations
{
    [DbContext(typeof(BasketDBContext))]
    [Migration("20190206155812_AddingBasketItemAsPK")]
    partial class AddingBasketItemAsPK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommercePrototype.API.Basket.Models.BasketItem", b =>
                {
                    b.Property<int>("basketItem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CatalogueItemID");

                    b.Property<string>("ItemBrand");

                    b.Property<string>("ItemDescription");

                    b.Property<string>("ItemName");

                    b.Property<float>("ItemPrice");

                    b.Property<string>("ItemType");

                    b.Property<string>("Pic");

                    b.Property<int>("Quantity");

                    b.HasKey("basketItem");

                    b.ToTable("Basket");
                });
#pragma warning restore 612, 618
        }
    }
}
