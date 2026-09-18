using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepDive.Migrations
{
    /// <inheritdoc />
    public partial class images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Tanks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "RegulatorSets",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "RegulatorSets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Mask_Snorkels",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Mask_Snorkels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Finns",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Finns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "DivingSuits",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "DivingSuits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "BCDs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "BCDs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 1,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 2,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 3,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "BCDs",
                keyColumn: "BCDId",
                keyValue: 4,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 1,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 2,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 3,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 4,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 5,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 6,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 7,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 8,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 1,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 2,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 3,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 4,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 5,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 6,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 7,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 1,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 2,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 3,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 4,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 5,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 6,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 7,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RegulatorSets",
                keyColumn: "RegulatorSetId",
                keyValue: 1,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RegulatorSets",
                keyColumn: "RegulatorSetId",
                keyValue: 2,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RegulatorSets",
                keyColumn: "RegulatorSetId",
                keyValue: 3,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "TankId",
                keyValue: 1,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "TankId",
                keyValue: 2,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "TankId",
                keyValue: 3,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "TankId",
                keyValue: 4,
                columns: new[] { "ImageData", "ImageMimeType" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "RegulatorSets");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "RegulatorSets");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Mask_Snorkels");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Mask_Snorkels");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Finns");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Finns");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "DivingSuits");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "DivingSuits");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "BCDs");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "BCDs");
        }
    }
}
