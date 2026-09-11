using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepDive.Migrations
{
    /// <inheritdoc />
    public partial class DivingSuitsEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 1,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre,Dame", "XS,S,M,L,XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 2,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre,Dame", "XS,S,M,L,XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 3,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre,Dame", "XS,S,M,L,XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 4,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre,Dame", "XS,S,M,L,XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 5,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre,Dame", "XS,S,M,L,XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 6,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre,Dame", "XS,S,M,L,XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 7,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre,Dame", "XS,S,M,L,XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 8,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre,Dame", "XS,S,M,L,XL" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 1,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre/Dame", "XS, S, M, L, XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 2,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre/Dame", "XS, S, M, L, XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 3,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre/Dame", "XS, S, M, L, XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 4,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre/Dame", "XS, S, M, L, XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 5,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre/Dame", "XS, S, M, L, XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 6,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre/Dame", "XS, S, M, L, XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 7,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre/Dame", "XS, S, M, L, XL" });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 8,
                columns: new[] { "Gender", "Size" },
                values: new object[] { "Herre/Dame", "XS, S, M, L, XL" });
        }
    }
}
