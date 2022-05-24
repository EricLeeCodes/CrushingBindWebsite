using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchiveModels",
                columns: table => new
                {
                    ArchiveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArchiveThumbnailImagePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    ArchiveChapterNumber = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveModels", x => x.ArchiveId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ArchiveThumbnailImagePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Excerpt = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    PublishDate = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Published = table.Column<bool>(type: "INTEGER", nullable: false),
                    ArchiveId = table.Column<int>(type: "INTEGER", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_ArchiveModels_ArchiveId",
                        column: x => x.ArchiveId,
                        principalTable: "ArchiveModels",
                        principalColumn: "ArchiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArchiveModels",
                columns: new[] { "ArchiveId", "ArchiveChapterNumber", "ArchiveThumbnailImagePath" },
                values: new object[] { 1, "Chapter 1", "uploads/Chapter_1_Thumbnail.png" });

            migrationBuilder.InsertData(
                table: "ArchiveModels",
                columns: new[] { "ArchiveId", "ArchiveChapterNumber", "ArchiveThumbnailImagePath" },
                values: new object[] { 2, "Chapter 2", "uploads/Chapter_2_Thumbnail.png" });

            migrationBuilder.InsertData(
                table: "ArchiveModels",
                columns: new[] { "ArchiveId", "ArchiveChapterNumber", "ArchiveThumbnailImagePath" },
                values: new object[] { 3, "Chapter 3", "uploads/Chapter_3_Thumbnail.png" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "773a1e1e-8f12-4069-860f-aaa294782bfe", "ac506b22-5e27-4b8b-bffc-db00eb5fecbf", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3edcf7c1-04e3-43ab-88dd-ca5764519791", 5, "69a22798-e61c-4011-b070-8f09b88bef8f", "admin@crushingbind.com", false, false, null, "ADMIN@CRUSHINGBIND.COM", "ADMIN@CRUSHINGBIND.COM", "AQAAAAEAACcQAAAAEBYpIVk44wjHzPToXVMzDog/MVgNh/wW4a35uWMASYka5f5s/wfmwXdlNh4o99hA5g==", null, false, "a7fed0e4-c586-4b00-bb92-d68572445768", false, "admin@crushingbind.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "773a1e1e-8f12-4069-860f-aaa294782bfe", "3edcf7c1-04e3-43ab-88dd-ca5764519791" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "PublishDate", "Published", "Title" },
                values: new object[] { 1, 1, "uploads/placeholder.jpg", "", "This is an excerpt example", "05/24/2022", true, "First post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "PublishDate", "Published", "Title" },
                values: new object[] { 2, 2, "uploads/placeholder.jpg", "", "This is an excerpt example", "05/24/2022", true, "Second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "PublishDate", "Published", "Title" },
                values: new object[] { 3, 3, "uploads/placeholder.jpg", "", "This is an excerpt example", "05/24/2022", true, "Third post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "PublishDate", "Published", "Title" },
                values: new object[] { 4, 1, "uploads/placeholder.jpg", "", "This is an excerpt example", "05/24/2022", true, "Fourth post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "PublishDate", "Published", "Title" },
                values: new object[] { 5, 2, "uploads/placeholder.jpg", "", "This is an excerpt example", "05/24/2022", true, "Fifth post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "PublishDate", "Published", "Title" },
                values: new object[] { 6, 3, "uploads/placeholder.jpg", "", "This is an excerpt example", "05/24/2022", true, "Sixth post" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ArchiveId",
                table: "Posts",
                column: "ArchiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ArchiveModels");
        }
    }
}
