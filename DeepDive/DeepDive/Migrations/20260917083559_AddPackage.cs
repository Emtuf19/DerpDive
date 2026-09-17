using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeepDive.Migrations
{
    /// <inheritdoc />
    public partial class AddPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "PackageItems",
                columns: table => new
                {
                    PackageItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentType = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageItems", x => x.PackageItemId);
                    table.ForeignKey(
                        name: "FK_PackageItems_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 80, "Lille pakke" },
                    { 2, 744, "Stor pakke" }
                });

            migrationBuilder.InsertData(
                table: "PackageItems",
                columns: new[] { "PackageItemId", "EquipmentId", "EquipmentType", "PackageId" },
                values: new object[,]
                {
                    { 1, 2, 2, 1 },
                    { 2, 3, 3, 1 },
                    { 3, 3, 0, 2 },
                    { 4, 6, 1, 2 },
                    { 5, 4, 5, 2 },
                    { 6, 3, 4, 2 },
                    { 7, 1, 2, 2 },
                    { 8, 1, 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageItems_PackageId",
                table: "PackageItems",
                column: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageItems");

            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
