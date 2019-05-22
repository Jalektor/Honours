using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommercePrototype.API.Basket.Migrations
{
    public partial class UpdatingPriceToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ItemPrice",
                table: "Basket",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ItemPrice",
                table: "Basket",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
