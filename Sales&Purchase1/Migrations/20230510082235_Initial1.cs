using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales_Purchase1.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactCode = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    ContactComName = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactMobile = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactDirectDail = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactFax = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactWeb = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactGroup = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactPerson1 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactAddress1 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactZipCode1 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactCity1 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactCountry1 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactPerson2 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactAddress2 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactZipCode2 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactCity2 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactCountry2 = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ContactUser = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Id",
                table: "Contacts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
