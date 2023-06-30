using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales_Purchase1.Migrations
{
    public partial class all1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_ChartofAcc_AccId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AccId",
                table: "Transactions",
                newName: "IX_Transactions_AccId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TId");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCost = table.Column<double>(type: "float", nullable: false),
                    ProductPurchaseRate = table.Column<float>(type: "real", nullable: false),
                    ProductPurchasAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPurchaseDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductActive = table.Column<int>(type: "int", nullable: false),
                    ProductSellPrice = table.Column<double>(type: "float", nullable: false),
                    ProductSellRate = table.Column<float>(type: "real", nullable: false),
                    ProductSellAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSellDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductStock = table.Column<int>(type: "int", nullable: false),
                    ProductUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    TRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TRName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TRAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TRPurhaseT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TRSalesT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TRCompenats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TRRate = table.Column<float>(type: "real", nullable: false),
                    TRUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.TRId);
                });

            migrationBuilder.CreateTable(
                name: "SalesPurchases",
                columns: table => new
                {
                    DocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocExpTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocTotalPrice = table.Column<double>(type: "float", nullable: true),
                    DocOutstanding = table.Column<double>(type: "float", nullable: true),
                    DocUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    TRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPurchases", x => x.DocId);
                    table.ForeignKey(
                        name: "FK_SalesPurchases_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId");
                    table.ForeignKey(
                        name: "FK_SalesPurchases_TaxRates_TRId",
                        column: x => x.TRId,
                        principalTable: "TaxRates",
                        principalColumn: "TRId");
                });

            migrationBuilder.CreateTable(
                name: "ItemLists",
                columns: table => new
                {
                    DocId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemQty = table.Column<int>(type: "int", nullable: false),
                    ItemUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPrice = table.Column<double>(type: "float", nullable: false),
                    ItemUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLists", x => new { x.DocId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ItemLists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemLists_SalesPurchases_DocId",
                        column: x => x.DocId,
                        principalTable: "SalesPurchases",
                        principalColumn: "DocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaycDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayAmount = table.Column<double>(type: "float", nullable: false),
                    PayUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PayId);
                    table.ForeignKey(
                        name: "FK_Payments_SalesPurchases_DocId",
                        column: x => x.DocId,
                        principalTable: "SalesPurchases",
                        principalColumn: "DocId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemLists_ProductId",
                table: "ItemLists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DocId",
                table: "Payments",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPurchases_ContactId",
                table: "SalesPurchases",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPurchases_TRId",
                table: "SalesPurchases",
                column: "TRId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ChartofAcc_AccId",
                table: "Transactions",
                column: "AccId",
                principalTable: "ChartofAcc",
                principalColumn: "AccId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ChartofAcc_AccId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "ItemLists");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SalesPurchases");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccId",
                table: "Transaction",
                newName: "IX_Transaction_AccId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "TId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_ChartofAcc_AccId",
                table: "Transaction",
                column: "AccId",
                principalTable: "ChartofAcc",
                principalColumn: "AccId");
        }
    }
}
