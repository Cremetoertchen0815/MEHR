using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEHR.Migrations
{
    /// <inheritdoc />
    public partial class AddressInclude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "FoodLocations",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "FoodLocations");
        }
    }
}
