using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaGaijinData.Migrations
{
    public partial class newi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Users_UserID",
                table: "Manga");

            migrationBuilder.DropIndex(
                name: "IX_Manga_UserID",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "MangaCollectionId",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "chapterNo",
                table: "Manga");

            migrationBuilder.CreateTable(
                name: "MangaCollections",
                columns: table => new
                {
                    MangaCollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<int>(type: "int", nullable: false),
                    MangaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chapters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    chapterNo = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaCollections", x => x.MangaCollectionId);
                    table.ForeignKey(
                        name: "FK_MangaCollections_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MangaCollections_UserID",
                table: "MangaCollections",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaCollections");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Manga",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MangaCollectionId",
                table: "Manga",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Manga",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Manga",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Manga",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "chapterNo",
                table: "Manga",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manga_UserID",
                table: "Manga",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Users_UserID",
                table: "Manga",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
