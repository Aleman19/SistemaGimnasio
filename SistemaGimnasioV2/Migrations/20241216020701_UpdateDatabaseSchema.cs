using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGimnasioV2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_AssignedTrainerId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AssignedTrainerId",
                table: "Users",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AssignedTrainerId",
                table: "Users",
                newName: "IX_Users_TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_TrainerId",
                table: "Users",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_TrainerId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Users",
                newName: "AssignedTrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TrainerId",
                table: "Users",
                newName: "IX_Users_AssignedTrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_AssignedTrainerId",
                table: "Users",
                column: "AssignedTrainerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
