using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales_Purchase1.Migrations
{
    public partial class SPIL1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPurchases_Contacts_ContactId",
                table: "SalesPurchases");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "SalesPurchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPurchases_Contacts_ContactId",
                table: "SalesPurchases",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPurchases_Contacts_ContactId",
                table: "SalesPurchases");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "SalesPurchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPurchases_Contacts_ContactId",
                table: "SalesPurchases",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId");
        }
    }
}
