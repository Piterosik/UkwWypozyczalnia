using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UkwWypozyczalnia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Komedia" },
                    { 2, "Horror" },
                    { 3, "Fantasy" },
                    { 4, "Familijne" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "CategoryId", "Director", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Person A", 17.49f, "Film A" },
                    { 2, 2, "Person B", 24.89f, "Film B" },
                    { 3, 3, "Person C", 31.39f, "Film C" },
                    { 4, 4, "Person D", 15.41f, "Film D" },
                    { 5, 3, "Person D", 12.25f, "Film E" },
                    { 6, 3, "Person D", 1.79f, "Film F" },
                    { 7, 2, "Person A", 37.43f, "Film G" },
                    { 8, 1, "Person B", 57.46f, "Film H" },
                    { 9, 4, "Person C", 27.29f, "Film I" },
                    { 10, 1, "Person B", 19.99f, "Film J" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategoryId",
                table: "Films",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
