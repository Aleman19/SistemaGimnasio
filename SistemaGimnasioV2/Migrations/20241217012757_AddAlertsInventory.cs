using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGimnasioV2.Migrations
{
    /// <inheritdoc />
    public partial class AddAlertsInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNotified",
                table: "InventoryItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LifeSpanMonths",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "InventoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNotified",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "LifeSpanMonths",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "InventoryItems");
        }
    }
}
