using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Websad.Storage.SQLite.Migrations
{
    public partial class AddBodyPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodyType",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApiKey", "RegisterDate" },
                values: new object[] { "QKwajfrtrJc0v9RsofSkxSSIz84eeAgqclQfOw34", new DateTime(2020, 8, 30, 20, 21, 39, 116, DateTimeKind.Utc).AddTicks(5385) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApiKey", "RegisterDate" },
                values: new object[] { "LSXdTkaibQGrjjVnXrgZrxtSClgPEkkJQdpvOU5r", new DateTime(2020, 8, 29, 11, 30, 14, 872, DateTimeKind.Utc).AddTicks(8533) });
        }
    }
}
