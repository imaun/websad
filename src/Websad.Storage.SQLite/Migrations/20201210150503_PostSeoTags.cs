using Microsoft.EntityFrameworkCore.Migrations;

namespace Websad.Storage.SQLite.Migrations
{
    public partial class PostSeoTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaRobots",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MetaRobots",
                table: "Posts");

        }
    }
}
