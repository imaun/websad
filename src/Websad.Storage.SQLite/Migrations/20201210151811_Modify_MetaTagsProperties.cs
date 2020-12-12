using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Websad.Storage.SQLite.Migrations
{
    public partial class Modify_MetaTagsProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApiKey", "RegisterDate" },
                values: new object[] { "1jDe3Zmr8dUNBXfjrWodOHRvHGmXNoVk7t02aoA6", new DateTime(2020, 12, 10, 15, 18, 10, 494, DateTimeKind.Utc).AddTicks(610) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApiKey", "RegisterDate" },
                values: new object[] { "9xRQ66fk9KNKnwIa9bW32JNHvv6yqBC7GeNThDo1", new DateTime(2020, 12, 10, 15, 5, 3, 240, DateTimeKind.Utc).AddTicks(4991) });
        }
    }
}
