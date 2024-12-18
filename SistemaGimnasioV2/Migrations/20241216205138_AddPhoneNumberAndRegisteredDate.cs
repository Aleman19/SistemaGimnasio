using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGimnasioV2.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberAndRegisteredDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredDate",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegisteredDate",
                table: "Users");
        }
    }
}
