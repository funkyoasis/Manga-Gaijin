using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaGaijinData.Migrations
{
    public partial class reviseddatabases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "MangaCollections");

            migrationBuilder.DropColumn(
                name: "Chapters",
                table: "MangaCollections");

            migrationBuilder.DropColumn(
                name: "MangaTitle",
                table: "MangaCollections");

            migrationBuilder.AlterColumn<int>(
                name: "MangaId",
                table: "MangaCollections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MangaCollections_MangaId",
                table: "MangaCollections",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MangaCollections_Manga_MangaId",
                table: "MangaCollections",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "MangaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaCollections_Manga_MangaId",
                table: "MangaCollections");

            migrationBuilder.DropIndex(
                name: "IX_MangaCollections_MangaId",
                table: "MangaCollections");

            migrationBuilder.AlterColumn<int>(
                name: "MangaId",
                table: "MangaCollections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "MangaCollections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Chapters",
                table: "MangaCollections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MangaTitle",
                table: "MangaCollections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
