using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEHR.Migrations
{
    /// <inheritdoc />
    public partial class newRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodLocations_Target",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_FoodLocations_Target",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_Author",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "Target",
                table: "Ratings",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_Target",
                table: "Ratings",
                newName: "IX_Ratings_LocationId");

            migrationBuilder.RenameColumn(
                name: "Target",
                table: "Foods",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "Foods",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_Target",
                table: "Foods",
                newName: "IX_Foods_TagId");

            migrationBuilder.AlterColumn<int>(
                name: "Author",
                table: "Ratings",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_LocationId",
                table: "Foods",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodLocations_LocationId",
                table: "Foods",
                column: "LocationId",
                principalTable: "FoodLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodTags_TagId",
                table: "Foods",
                column: "TagId",
                principalTable: "FoodTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_FoodLocations_LocationId",
                table: "Ratings",
                column: "LocationId",
                principalTable: "FoodLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_Author",
                table: "Ratings",
                column: "Author",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodLocations_LocationId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodTags_TagId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_FoodLocations_LocationId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_Author",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Foods_LocationId",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Ratings",
                newName: "Target");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_LocationId",
                table: "Ratings",
                newName: "IX_Ratings_Target");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Foods",
                newName: "Target");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Foods",
                newName: "Tag");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_TagId",
                table: "Foods",
                newName: "IX_Foods_Target");

            migrationBuilder.AlterColumn<int>(
                name: "Author",
                table: "Ratings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodLocations_Target",
                table: "Foods",
                column: "Target",
                principalTable: "FoodLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_FoodLocations_Target",
                table: "Ratings",
                column: "Target",
                principalTable: "FoodLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_Author",
                table: "Ratings",
                column: "Author",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
