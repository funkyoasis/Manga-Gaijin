using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaGaijinData.Migrations
{
    public partial class reviseddatabasessss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaCollections_Users_UserID",
                table: "MangaCollections");

            migrationBuilder.DropIndex(
                name: "IX_MangaCollections_UserID",
                table: "MangaCollections");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "MangaCollections");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MangaCollectionLink",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MangaCollectionLink_UserId",
                table: "MangaCollectionLink",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MangaCollectionLink_Users_UserId",
                table: "MangaCollectionLink",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaCollectionLink_Users_UserId",
                table: "MangaCollectionLink");

            migrationBuilder.DropIndex(
                name: "IX_MangaCollectionLink_UserId",
                table: "MangaCollectionLink");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MangaCollectionLink");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "MangaCollections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MangaCollections_UserID",
                table: "MangaCollections",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_MangaCollections_Users_UserID",
                table: "MangaCollections",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
