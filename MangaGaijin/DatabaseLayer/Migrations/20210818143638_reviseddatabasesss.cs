using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaGaijinData.Migrations
{
    public partial class reviseddatabasesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaCollections_Manga_MangaId",
                table: "MangaCollections");

            migrationBuilder.DropIndex(
                name: "IX_MangaCollections_MangaId",
                table: "MangaCollections");

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "MangaCollections");

            migrationBuilder.CreateTable(
                name: "MangaCollectionLink",
                columns: table => new
                {
                    MangaCollectionLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<int>(type: "int", nullable: false),
                    MangaCollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaCollectionLink", x => x.MangaCollectionLinkId);
                    table.ForeignKey(
                        name: "FK_MangaCollectionLink_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaCollectionLink_MangaCollections_MangaCollectionId",
                        column: x => x.MangaCollectionId,
                        principalTable: "MangaCollections",
                        principalColumn: "MangaCollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MangaCollectionLink_MangaCollectionId",
                table: "MangaCollectionLink",
                column: "MangaCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaCollectionLink_MangaId",
                table: "MangaCollectionLink",
                column: "MangaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaCollectionLink");

            migrationBuilder.AddColumn<int>(
                name: "MangaId",
                table: "MangaCollections",
                type: "int",
                nullable: true);

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
    }
}
