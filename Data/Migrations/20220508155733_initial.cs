using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    IdSession = table.Column<int>(type: "int", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false),
                    IdService = table.Column<int>(type: "int", nullable: false),
                    TrackingCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdServant = table.Column<int>(type: "int", nullable: false),
                    ShabaId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    TypeAccountPay = table.Column<int>(type: "int", nullable: false),
                    SpecialCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSend = table.Column<int>(type: "int", nullable: false),
                    StatusPay = table.Column<int>(type: "int", nullable: false),
                    BankComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RRN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
