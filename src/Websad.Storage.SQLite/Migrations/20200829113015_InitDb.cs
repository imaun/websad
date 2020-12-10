using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Websad.Storage.SQLite.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Slug = table.Column<string>(maxLength: 400, nullable: false),
                    Lang = table.Column<string>(maxLength: 20, nullable: true),
                    PostType = table.Column<string>(maxLength: 100, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteVisits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SessionId = table.Column<string>(maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    AbsoluteUrl = table.Column<string>(maxLength: 4000, nullable: true),
                    UrlReferrer = table.Column<string>(maxLength: 4000, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    IP = table.Column<string>(maxLength: 100, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 100, nullable: true),
                    OsPlatform = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Region = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteVisits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<int>(nullable: false),
                    Role = table.Column<string>(maxLength: 20, nullable: true),
                    Username = table.Column<string>(maxLength: 1000, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 1000, nullable: false),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    WebUrl = table.Column<string>(maxLength: 2000, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ApiKey = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 1000, nullable: true),
                    FilePath = table.Column<string>(maxLength: 2000, nullable: false),
                    FileTypeIndex = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Slug = table.Column<string>(maxLength: 2000, nullable: true),
                    Body = table.Column<string>(maxLength: 4000, nullable: true),
                    Summary = table.Column<string>(maxLength: 2000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    Commenting = table.Column<bool>(nullable: false),
                    PostType = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    Lang = table.Column<string>(maxLength: 20, nullable: true),
                    CoverPhoto = table.Column<string>(maxLength: 2000, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    AltTitle = table.Column<string>(maxLength: 2000, nullable: true),
                    OrderNumber = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<int>(nullable: false),
                    Author = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    Message = table.Column<string>(maxLength: 4000, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Ip = table.Column<string>(maxLength: 100, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(maxLength: 100, nullable: true),
                    Url = table.Column<string>(maxLength: 3000, nullable: true),
                    PostId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Post_Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostId = table.Column<int>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Files_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Post_Files_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Post_Likes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostId = table.Column<int>(nullable: false),
                    SessionId = table.Column<string>(maxLength: 2000, nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    IP = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post_Meta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostId = table.Column<int>(nullable: false),
                    MetaKey = table.Column<string>(maxLength: 200, nullable: false),
                    MetaValue = table.Column<string>(maxLength: 4000, nullable: true),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Lang = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Meta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Meta_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Lang", "ParentId", "PostType", "Slug", "Status", "Title" },
                values: new object[] { 1, null, "fa", null, "page", "uncategorized", 1, "دسته بندی نشده" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ApiKey", "Description", "Email", "Enabled", "LockoutEnabled", "LockoutEnd", "PasswordHash", "Phone", "RegisterDate", "Role", "Status", "Title", "Username", "WebUrl" },
                values: new object[] { 1, "LSXdTkaibQGrjjVnXrgZrxtSClgPEkkJQdpvOU5r", null, "admin@site.com", true, false, null, "e4uD8ajpPMmqVo5Rs/hL1g==", null, new DateTime(2020, 8, 29, 11, 30, 14, 872, DateTimeKind.Utc).AddTicks(8533), "modir", 1, "Admin", "modir", null });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Files_FileId",
                table: "Post_Files",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Files_PostId",
                table: "Post_Files",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Likes_PostId",
                table: "Post_Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Likes_UserId",
                table: "Post_Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Meta_PostId",
                table: "Post_Meta",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Post_Files");

            migrationBuilder.DropTable(
                name: "Post_Likes");

            migrationBuilder.DropTable(
                name: "Post_Meta");

            migrationBuilder.DropTable(
                name: "SiteVisits");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
