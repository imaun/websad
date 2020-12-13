using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Websad.Storage.SQLite.Migrations
{
    public partial class DesignBlocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false),
                    Icon = table.Column<string>(maxLength: 100, nullable: true),
                    Author = table.Column<string>(maxLength: 300, nullable: false),
                    AuthorEmail = table.Column<string>(maxLength: 1000, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Src = table.Column<string>(nullable: false),
                    Attributes = table.Column<string>(nullable: true),
                    BodyType = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 2000, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Keywords = table.Column<string>(maxLength: 1000, nullable: true),
                    AddedByUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blocks_Blocks_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Block_Samples",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    BlockId = table.Column<Guid>(nullable: false),
                    Attributes = table.Column<string>(nullable: true),
                    OutputSrc = table.Column<string>(nullable: false),
                    BodyType = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block_Samples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Block_Samples_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post_Blocks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostId = table.Column<int>(nullable: false),
                    BlockId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    OutputSrc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Blocks_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Blocks_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Blocks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApiKey", "RegisterDate" },
                values: new object[] { "yfaUCvORbh6a0jFfE0yvCp0pLVDXkGSBPxGKeYBB", new DateTime(2020, 12, 13, 7, 28, 1, 499, DateTimeKind.Utc).AddTicks(3853) });

            migrationBuilder.CreateIndex(
                name: "IX_Block_Samples_BlockId",
                table: "Block_Samples",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_AddedByUserId",
                table: "Blocks",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_ParentId",
                table: "Blocks",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Blocks_BlockId",
                table: "Post_Blocks",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Blocks_PostId",
                table: "Post_Blocks",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Blocks_UserId",
                table: "Post_Blocks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Block_Samples");

            migrationBuilder.DropTable(
                name: "Post_Blocks");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApiKey", "RegisterDate" },
                values: new object[] { "1jDe3Zmr8dUNBXfjrWodOHRvHGmXNoVk7t02aoA6", new DateTime(2020, 12, 10, 15, 18, 10, 494, DateTimeKind.Utc).AddTicks(610) });
        }
    }
}
