using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QaFullStack.Migrations
{
    public partial class CreateDBEstate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BUYER_ID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "GARDEN",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NUMBER_OF_BATHROOMS",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NUMBER_OF_BEDROOMS",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "POSTCODE",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PRICE",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SELLER_ID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TYPE",
                table: "Properties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BUYER_ID",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GARDEN",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NUMBER_OF_BATHROOMS",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NUMBER_OF_BEDROOMS",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "POSTCODE",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PRICE",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SELLER_ID",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TYPE",
                table: "Properties",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");
        }
    }
}
