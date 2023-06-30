using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales_Purchase1.Migrations
{
    public partial class c1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChartofAcc",
                columns: table => new
                {
                    AccId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccCode = table.Column<int>(type: "int", nullable: false),
                    AccName = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    AccDesc = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccType = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    AccYTD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acclock = table.Column<int>(type: "int", nullable: false),
                    AccUser = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartofAcc", x => x.AccId);
                    table.ForeignKey(
                        name: "FK_ChartofAcc_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TDebit = table.Column<double>(type: "float", nullable: true),
                    TCredit = table.Column<double>(type: "float", nullable: true),
                    TUser = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    AccId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TId);
                    table.ForeignKey(
                        name: "FK_Transaction_ChartofAcc_AccId",
                        column: x => x.AccId,
                        principalTable: "ChartofAcc",
                        principalColumn: "AccId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChartofAcc_Id",
                table: "ChartofAcc",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccId",
                table: "Transaction",
                column: "AccId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "ChartofAcc");
        }
    }
}
