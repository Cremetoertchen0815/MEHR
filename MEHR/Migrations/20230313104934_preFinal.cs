using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEHR.Migrations
{
    /// <inheritdoc />
    public partial class preFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_Author",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_Author",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Ratings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AuthorId",
                table: "Ratings",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_AuthorId",
                table: "Ratings",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_AuthorId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_AuthorId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "Author",
                table: "Ratings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Author",
                table: "Ratings",
                column: "Author");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_Author",
                table: "Ratings",
                column: "Author",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
