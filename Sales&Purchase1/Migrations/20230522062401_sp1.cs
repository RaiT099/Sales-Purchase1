using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales_Purchase1.Migrations
{
    public partial class sp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DocDeliveryDate",
                table: "SalesPurchases",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocDeliveryDate",
                table: "SalesPurchases");
        }
    }
}
