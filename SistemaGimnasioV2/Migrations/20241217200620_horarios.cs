using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGimnasioV2.Migrations
{
    /// <inheritdoc />
    public partial class horarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "ClassSchedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "ClassSchedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ClassSchedules");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ClassSchedules");
        }
    }
}
