using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEHR.Migrations
{
    /// <inheritdoc />
    public partial class HistoryItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodLocations_Users_AppUserId",
                table: "FoodLocations");

            migrationBuilder.DropIndex(
                name: "IX_FoodLocations_AppUserId",
                table: "FoodLocations");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "FoodLocations");

            migrationBuilder.CreateTable(
                name: "HistoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryItems_FoodLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "FoodLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryItems_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryItems_LocationId",
                table: "HistoryItems",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryItems_OwnerId",
                table: "HistoryItems",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryItems");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "FoodLocations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodLocations_AppUserId",
                table: "FoodLocations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodLocations_Users_AppUserId",
                table: "FoodLocations",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
