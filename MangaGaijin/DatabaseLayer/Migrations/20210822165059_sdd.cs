using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaGaijinData.Migrations
{
    public partial class sdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manga_MangaCollectionLink_MangaCollectionLinkId",
                table: "Manga");

            migrationBuilder.DropForeignKey(
                name: "FK_MangaCollections_MangaCollectionLink_MangaCollectionLinkId",
                table: "MangaCollections");

            migrationBuilder.DropIndex(
                name: "IX_MangaCollections_MangaCollectionLinkId",
                table: "MangaCollections");

            migrationBuilder.DropIndex(
                name: "IX_Manga_MangaCollectionLinkId",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "MangaCollectionLinkId",
                table: "MangaCollections");

            migrationBuilder.DropColumn(
                name: "MangaCollectionLinkId",
                table: "Manga");

            migrationBuilder.CreateIndex(
                name: "IX_MangaCollectionLink_MangaCollectionId",
                table: "MangaCollectionLink",
                column: "MangaCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaCollectionLink_MangaId",
                table: "MangaCollectionLink",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MangaCollectionLink_Manga_MangaId",
                table: "MangaCollectionLink",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "MangaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MangaCollectionLink_MangaCollections_MangaCollectionId",
                table: "MangaCollectionLink",
                column: "MangaCollectionId",
                principalTable: "MangaCollections",
                principalColumn: "MangaCollectionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaCollectionLink_Manga_MangaId",
                table: "MangaCollectionLink");

            migrationBuilder.DropForeignKey(
                name: "FK_MangaCollectionLink_MangaCollections_MangaCollectionId",
                table: "MangaCollectionLink");

            migrationBuilder.DropIndex(
                name: "IX_MangaCollectionLink_MangaCollectionId",
                table: "MangaCollectionLink");

            migrationBuilder.DropIndex(
                name: "IX_MangaCollectionLink_MangaId",
                table: "MangaCollectionLink");

            migrationBuilder.AddColumn<int>(
                name: "MangaCollectionLinkId",
                table: "MangaCollections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MangaCollectionLinkId",
                table: "Manga",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MangaCollections_MangaCollectionLinkId",
                table: "MangaCollections",
                column: "MangaCollectionLinkId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MangaCollections_MangaCollectionLink_MangaCollectionLinkId",
                table: "MangaCollections",
                column: "MangaCollectionLinkId",
                principalTable: "MangaCollectionLink",
                principalColumn: "MangaCollectionLinkId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
