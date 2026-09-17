using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepDive.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersionBookingItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "BookingItems",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "BookingItems");
        }
    }
}
