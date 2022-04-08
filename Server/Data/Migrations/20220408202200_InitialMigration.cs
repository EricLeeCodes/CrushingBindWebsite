using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    public partial class InitialMigration : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveModels");
        }
    }
}
