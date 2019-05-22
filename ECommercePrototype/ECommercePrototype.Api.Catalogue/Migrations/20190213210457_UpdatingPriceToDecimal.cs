using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommercePrototype.Api.Catalogue.Migrations
{
    public partial class UpdatingPriceToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ItemPrice",
                table: "Catalogue",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ItemPrice",
                table: "Catalogue",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
