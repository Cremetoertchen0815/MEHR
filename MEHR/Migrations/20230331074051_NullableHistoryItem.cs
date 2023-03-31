using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEHR.Migrations
{
    /// <inheritdoc />
    public partial class NullableHistoryItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryItems_FoodLocations_LocationId",
                table: "HistoryItems");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "HistoryItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "HistoryItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryItems_FoodLocations_LocationId",
                table: "HistoryItems",
                column: "LocationId",
                principalTable: "FoodLocations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryItems_FoodLocations_LocationId",
                table: "HistoryItems");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "HistoryItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "HistoryItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryItems_FoodLocations_LocationId",
                table: "HistoryItems",
                column: "LocationId",
                principalTable: "FoodLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
