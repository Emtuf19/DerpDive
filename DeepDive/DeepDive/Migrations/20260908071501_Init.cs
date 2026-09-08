using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeepDive.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BCDs",
                columns: table => new
                {
                    BCDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCDs", x => x.BCDId);
                });

            migrationBuilder.CreateTable(
                name: "DivingSuits",
                columns: table => new
                {
                    DivingSuitsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thickness = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingSuits", x => x.DivingSuitsId);
                });

            migrationBuilder.CreateTable(
                name: "Finns",
                columns: table => new
                {
                    FinnsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finns", x => x.FinnsId);
                });

            migrationBuilder.CreateTable(
                name: "Mask_Snokels",
                columns: table => new
                {
                    Mask_SnorkelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_Snokels", x => x.Mask_SnorkelId);
                });

            migrationBuilder.CreateTable(
                name: "RegulatorSets",
                columns: table => new
                {
                    RegulatorSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstStep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondStep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Octopus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegulatorSets", x => x.RegulatorSetId);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    TankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volumen = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.TankId);
                });

            migrationBuilder.InsertData(
                table: "BCDs",
                columns: new[] { "BCDId", "Brand", "Model", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "Scubapro", "Navigator Lite BCD", 125.0, "S, M, L" },
                    { 2, "Scubapro", "BCD Glide", 140.0, "S, M, L" },
                    { 3, "Scubapro", "BCD Hydros Pro", 200.0, "S, M, L" },
                    { 4, "Seac", "BCD Modular", 145.0, "S, M, L" }
                });

            migrationBuilder.InsertData(
                table: "DivingSuits",
                columns: new[] { "DivingSuitsId", "Brand", "Gender", "Model", "Price", "Size", "Thickness", "Type" },
                values: new object[,]
                {
                    { 1, "Scubapro", "Herre/Dame", "Definition", 100.0, "XS, S, M, L, XL", 3, "Våddragt" },
                    { 2, "Scubapro", "Herre/Dame", "Definition", 100.0, "XS, S, M, L, XL", 5, "Våddragt" },
                    { 3, "Scubapro", "Herre/Dame", "Definition", 100.0, "XS, S, M, L, XL", 7, "Våddragt" },
                    { 4, "Waterproof", "Herre/Dame", "W5", 100.0, "XS, S, M, L, XL", 3, "Våddragt" },
                    { 5, "Fourth Element", "Herre/Dame", "Proteus", 120.0, "XS, S, M, L, XL", 5, "Våddragt" },
                    { 6, "Scubapro", "Herre/Dame", "Exodry 4.0", 300.0, "XS, S, M, L, XL", 0, "Tørdragt" },
                    { 7, "Waterproof", "Herre/Dame", "D7 Evo", 320.0, "XS, S, M, L, XL", 0, "Tørdragt" },
                    { 8, "Santi", "Herre/Dame", "E.Lite Plus", 350.0, "XS, S, M, L, XL", 0, "Tørdragt" }
                });

            migrationBuilder.InsertData(
                table: "Finns",
                columns: new[] { "FinnsId", "Brand", "Model", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "Scubapro", "Jet Fin", 50.0, "XS, S, M, L, XL" },
                    { 2, "Scubapro", "GO Travel", 50.0, "XS, S, M, L, XL" },
                    { 3, "Scubapro", "Seawing Supernova", 60.0, "XS, S, M, L, XL" },
                    { 4, "Seac", "Propulsion", 50.0, "XS, S, M, L, XL" },
                    { 5, "Seac", "ALA", 50.0, "XS, S, M, L, XL" },
                    { 6, "Fourth Element", "Tech", 75.0, "XS, S, M, L, XL" },
                    { 7, "Fourth Element", "Rec Fin", 80.0, "XS, S, M, L, XL" }
                });

            migrationBuilder.InsertData(
                table: "Mask_Snokels",
                columns: new[] { "Mask_SnorkelId", "Brand", "Model", "Price" },
                values: new object[,]
                {
                    { 1, "Scubapro", "Ghost", 50.0 },
                    { 2, "Scubapro", "D-Mask", 60.0 },
                    { 3, "Scubapro", "Spectra Mini", 50.0 },
                    { 4, "Scubapro", "Crystal VU", 75.0 },
                    { 5, "Fourth Element", "Scout Kontrast", 75.0 },
                    { 6, "Fourth Element", "Scout Enhance", 75.0 },
                    { 7, "Tusa", "Element", 75.0 }
                });

            migrationBuilder.InsertData(
                table: "RegulatorSets",
                columns: new[] { "RegulatorSetId", "Brand", "FirstStep", "Octopus", "Price", "SecondStep" },
                values: new object[,]
                {
                    { 1, "Scubapro", "MK25EVO", "R105", 125.0, "S600" },
                    { 2, "Scubapro", "MK17EVO", "R095", 100.0, "C370" },
                    { 3, "Scubapro", "MK25EVO BT", "S270", 150.0, "A700 Carbon BT" }
                });

            migrationBuilder.InsertData(
                table: "Tanks",
                columns: new[] { "TankId", "Brand", "Price", "Volumen" },
                values: new object[,]
                {
                    { 1, "Scubapro", 150.0, 5 },
                    { 2, "Scubapro", 160.0, 10 },
                    { 3, "Scubapro", 170.0, 12 },
                    { 4, "Scubapro", 180.0, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BCDs");

            migrationBuilder.DropTable(
                name: "DivingSuits");

            migrationBuilder.DropTable(
                name: "Finns");

            migrationBuilder.DropTable(
                name: "Mask_Snokels");

            migrationBuilder.DropTable(
                name: "RegulatorSets");

            migrationBuilder.DropTable(
                name: "Tanks");
        }
    }
}
