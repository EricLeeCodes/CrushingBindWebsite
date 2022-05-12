using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    public partial class InitialPostMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    IntroBorder = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
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

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "IntroBorder", "PublishDate", "Published", "Title" },
                values: new object[] { 1, 1, "uploads/placeholder.jpg", "", "This is an excerpt example", "uploads/intro_border.png", "05/12/2022", true, "First post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "IntroBorder", "PublishDate", "Published", "Title" },
                values: new object[] { 2, 2, "uploads/placeholder.jpg", "", "This is an excerpt example", "uploads/intro_border.png", "05/12/2022", true, "Second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "IntroBorder", "PublishDate", "Published", "Title" },
                values: new object[] { 3, 3, "uploads/placeholder.jpg", "", "This is an excerpt example", "uploads/intro_border.png", "05/12/2022", true, "Third post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "IntroBorder", "PublishDate", "Published", "Title" },
                values: new object[] { 4, 1, "uploads/placeholder.jpg", "", "This is an excerpt example", "uploads/intro_border.png", "05/12/2022", true, "Fourth post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "IntroBorder", "PublishDate", "Published", "Title" },
                values: new object[] { 5, 2, "uploads/placeholder.jpg", "", "This is an excerpt example", "uploads/intro_border.png", "05/12/2022", true, "Fifth post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "ArchiveId", "ArchiveThumbnailImagePath", "Content", "Excerpt", "IntroBorder", "PublishDate", "Published", "Title" },
                values: new object[] { 6, 3, "uploads/placeholder.jpg", "", "This is an excerpt example", "uploads/intro_border.png", "05/12/2022", true, "Sixth post" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ArchiveId",
                table: "Posts",
                column: "ArchiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
