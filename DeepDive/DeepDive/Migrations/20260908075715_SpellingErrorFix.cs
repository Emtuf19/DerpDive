using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepDive.Migrations
{
    /// <inheritdoc />
    public partial class SpellingErrorFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mask_Snokels",
                table: "Mask_Snokels");

            migrationBuilder.RenameTable(
                name: "Mask_Snokels",
                newName: "Mask_Snorkels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mask_Snorkels",
                table: "Mask_Snorkels",
                column: "Mask_SnorkelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mask_Snorkels",
                table: "Mask_Snorkels");

            migrationBuilder.RenameTable(
                name: "Mask_Snorkels",
                newName: "Mask_Snokels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mask_Snokels",
                table: "Mask_Snokels",
                column: "Mask_SnorkelId");
        }
    }
}
