using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archives",
                columns: table => new
                {
                    ArchiveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArchiveImagePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    ArchiveChapterNumber = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archives", x => x.ArchiveId);
                });

            migrationBuilder.InsertData(
                table: "Archives",
                columns: new[] { "ArchiveId", "ArchiveChapterNumber", "ArchiveImagePath" },
                values: new object[] { 1, "Chapter 1", "uploads/placeholder.jpg" });

            migrationBuilder.InsertData(
                table: "Archives",
                columns: new[] { "ArchiveId", "ArchiveChapterNumber", "ArchiveImagePath" },
                values: new object[] { 2, "Chapter 2", "uploads/placeholder.jpg" });

            migrationBuilder.InsertData(
                table: "Archives",
                columns: new[] { "ArchiveId", "ArchiveChapterNumber", "ArchiveImagePath" },
                values: new object[] { 3, "Chapter 3", "uploads/placeholder.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archives");
        }
    }
}
