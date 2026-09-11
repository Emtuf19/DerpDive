using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepDive.Migrations
{
    /// <inheritdoc />
    public partial class AddDateTimeAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Tanks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Tanks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "RegulatorSets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "RegulatorSets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Mask_Snorkels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Mask_Snorkels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Finns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Finns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "DivingSuits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "DivingSuits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 4,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 5,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 6,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 7,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DivingSuits",
                keyColumn: "DivingSuitsId",
                keyValue: 8,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 4,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 5,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 6,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Finns",
                keyColumn: "FinnsId",
                keyValue: 7,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 4,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 5,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 6,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mask_Snorkels",
                keyColumn: "Mask_SnorkelId",
                keyValue: 7,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "RegulatorSets",
                keyColumn: "RegulatorSetId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "RegulatorSets",
                keyColumn: "RegulatorSetId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "RegulatorSets",
                keyColumn: "RegulatorSetId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "TankId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "TankId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "TankId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tanks",
                keyColumn: "TankId",
                keyValue: 4,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "RegulatorSets");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "RegulatorSets");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Mask_Snorkels");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Mask_Snorkels");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Finns");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Finns");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "DivingSuits");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "DivingSuits");
        }
    }
}
