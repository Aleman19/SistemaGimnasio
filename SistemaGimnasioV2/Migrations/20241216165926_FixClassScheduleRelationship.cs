using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGimnasioV2.Migrations
{
    /// <inheritdoc />
    public partial class FixClassScheduleRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId",
                table: "ClassSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Users_TrainerId",
                table: "ClassSchedules");

            migrationBuilder.AddColumn<int>(
                name: "ClassId1",
                table: "ClassSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ClassSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedules_ClassId1",
                table: "ClassSchedules",
                column: "ClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedules_UserId",
                table: "ClassSchedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId",
                table: "ClassSchedules",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId1",
                table: "ClassSchedules",
                column: "ClassId1",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Users_TrainerId",
                table: "ClassSchedules",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Users_UserId",
                table: "ClassSchedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId",
                table: "ClassSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId1",
                table: "ClassSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Users_TrainerId",
                table: "ClassSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Users_UserId",
                table: "ClassSchedules");

            migrationBuilder.DropIndex(
                name: "IX_ClassSchedules_ClassId1",
                table: "ClassSchedules");

            migrationBuilder.DropIndex(
                name: "IX_ClassSchedules_UserId",
                table: "ClassSchedules");

            migrationBuilder.DropColumn(
                name: "ClassId1",
                table: "ClassSchedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ClassSchedules");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId",
                table: "ClassSchedules",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Users_TrainerId",
                table: "ClassSchedules",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
