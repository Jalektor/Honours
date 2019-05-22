using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommercePrototype.API.Checkout.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckoutItem",
                columns: table => new
                {
                    checkoutItem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<float>(nullable: false),
                    ItemBrand = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ItemPriceTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutItem", x => x.checkoutItem);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutItem");
        }
    }
}
