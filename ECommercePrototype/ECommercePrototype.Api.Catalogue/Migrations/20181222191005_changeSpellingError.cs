using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommercePrototype.Api.Catalogue.Migrations
{
    public partial class changeSpellingError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemAvailabkeStock",
                table: "Catalogue",
                newName: "ItemAvailableStock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemAvailableStock",
                table: "Catalogue",
                newName: "ItemAvailabkeStock");
        }
    }
}
