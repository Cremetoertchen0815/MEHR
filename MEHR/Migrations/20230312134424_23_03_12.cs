using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEHR.Migrations
{
    /// <inheritdoc />
    public partial class _23_03_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationLatitude = table.Column<double>(type: "REAL", nullable: false),
                    LocationLongitude = table.Column<double>(type: "REAL", nullable: false),
                    Icon = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    HasDelivery = table.Column<bool>(type: "INTEGER", nullable: false),
                    OpeningTimesSerial = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CookieHash = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Target = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LowerPriceRange = table.Column<decimal>(type: "TEXT", nullable: false),
                    UpperPriceRange = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tag = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_FoodLocations_Target",
                        column: x => x.Target,
                        principalTable: "FoodLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Target = table.Column<int>(type: "INTEGER", nullable: false),
                    Author = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<float>(type: "REAL", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_FoodLocations_Target",
                        column: x => x.Target,
                        principalTable: "FoodLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Target",
                table: "Foods",
                column: "Target");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Author",
                table: "Ratings",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Target",
                table: "Ratings",
                column: "Target");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "FoodTags");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "FoodLocations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
