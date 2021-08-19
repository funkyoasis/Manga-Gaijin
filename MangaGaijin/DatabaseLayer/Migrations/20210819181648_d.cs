using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaGaijinData.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MangaCollectionLinkId",
                table: "Manga",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manga_MangaCollectionLinkId",
                table: "Manga",
                column: "MangaCollectionLinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_MangaCollectionLink_MangaCollectionLinkId",
                table: "Manga",
                column: "MangaCollectionLinkId",
                principalTable: "MangaCollectionLink",
                principalColumn: "MangaCollectionLinkId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manga_MangaCollectionLink_MangaCollectionLinkId",
                table: "Manga");

            migrationBuilder.DropIndex(
                name: "IX_Manga_MangaCollectionLinkId",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "MangaCollectionLinkId",
                table: "Manga");
        }
    }
}
