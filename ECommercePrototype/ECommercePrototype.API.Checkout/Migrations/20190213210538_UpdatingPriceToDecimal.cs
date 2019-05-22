using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommercePrototype.API.Checkout.Migrations
{
    public partial class UpdatingPriceToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ItemPriceTotal",
                table: "CheckoutItem",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemPrice",
                table: "CheckoutItem",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ItemPriceTotal",
                table: "CheckoutItem",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "ItemPrice",
                table: "CheckoutItem",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
