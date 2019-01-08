using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommercePrototype.Api.Catalogue.Migrations
{
    public partial class AddingPicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pic",
                table: "Catalogue",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pic",
                table: "Catalogue");
        }
    }
}
