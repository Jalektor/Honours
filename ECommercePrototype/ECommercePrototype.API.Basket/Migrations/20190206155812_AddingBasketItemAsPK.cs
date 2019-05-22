using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommercePrototype.API.Basket.Migrations
{
    public partial class AddingBasketItemAsPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "CatalogueItemID",
                table: "Basket");

            migrationBuilder.AddColumn<int>(
                name: "CatalogueItemID",
                table: "Basket",
                nullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "CatalogueItemID",
            //    table: "Basket",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "basketItem",
                table: "Basket",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                table: "Basket",
                column: "basketItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "basketItem",
                table: "Basket");

            //migrationBuilder.AlterColumn<int>(
            //    name: "CatalogueItemID",
            //    table: "Basket",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                table: "Basket",
                column: "CatalogueItemID");
        }
    }
}
