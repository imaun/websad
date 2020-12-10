using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Websad.Storage.SQLite.Migrations
{
    public partial class AddWidgetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Widgets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    UniqueName = table.Column<string>(maxLength: 250, nullable: false),
                    Body = table.Column<string>(maxLength: 4000, nullable: true),
                    Category = table.Column<string>(maxLength: 100, nullable: true),
                    Lang = table.Column<string>(maxLength: 20, nullable: true),
                    OrderNumber = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widgets", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApiKey", "RegisterDate" },
                values: new object[] { "vbBOlgstmPrGeP0gUM7fWfC080Qus1Yt4V8Ftso2", new DateTime(2020, 9, 5, 7, 58, 38, 344, DateTimeKind.Utc).AddTicks(1151) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Widgets");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApiKey", "RegisterDate" },
                values: new object[] { "QKwajfrtrJc0v9RsofSkxSSIz84eeAgqclQfOw34", new DateTime(2020, 8, 30, 20, 21, 39, 116, DateTimeKind.Utc).AddTicks(5385) });
        }
    }
}
