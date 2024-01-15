using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QaFullStack.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BOOKING_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BUYER_ID = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PROPERTY_ID = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TIME = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BOOKING_ID);
                });

            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    BUYER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    POSTCODE = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.BUYER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Propertie",
                columns: table => new
                {
                    PROPERTY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDRESS = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    POSTCODE = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    NUMBER_OF_BEDROOMS = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NUMBER_OF_BATHROOMS = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    GARDEN = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PRICE = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SELLER_ID = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    BUYER_ID = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propertie", x => x.PROPERTY_ID);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    SELLER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    POSTCODE = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.SELLER_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Propertie");

            migrationBuilder.DropTable(
                name: "Seller");
        }
    }
}
