using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepDive.Migrations
{
    /// <inheritdoc />
    public partial class AddedFinnsSizeEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 1,
                column: "Size",
                value: "XS,S,M,L,XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 2,
                column: "Size",
                value: "XS,S,M,L,XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 3,
                column: "Size",
                value: "XS,S,M,L,XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 4,
                column: "Size",
                value: "XS,S,M,L,XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 5,
                column: "Size",
                value: "XS,S,M,L,XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 6,
                column: "Size",
                value: "XS,S,M,L,XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 7,
                column: "Size",
                value: "XS,S,M,L,XL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 1,
                column: "Size",
                value: "XS, S, M, L, XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 2,
                column: "Size",
                value: "XS, S, M, L, XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 3,
                column: "Size",
                value: "XS, S, M, L, XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 4,
                column: "Size",
                value: "XS, S, M, L, XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 5,
                column: "Size",
                value: "XS, S, M, L, XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 6,
                column: "Size",
                value: "XS, S, M, L, XL");

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 7,
                column: "Size",
                value: "XS, S, M, L, XL");
        }
    }
}
