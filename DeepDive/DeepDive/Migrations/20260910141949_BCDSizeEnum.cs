using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepDive.Migrations
{
    /// <inheritdoc />
    public partial class BCDSizeEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 1,
                column: "Size",
                value: "S,M,L");

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 2,
                column: "Size",
                value: "S,M,L");

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 3,
                column: "Size",
                value: "S,M,L");

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 4,
                column: "Size",
                value: "S,M,L");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 1,
                column: "Size",
                value: "S, M, L");

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 2,
                column: "Size",
                value: "S, M, L");

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 3,
                column: "Size",
                value: "S, M, L");

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 4,
                column: "Size",
                value: "S, M, L");
        }
    }
}
