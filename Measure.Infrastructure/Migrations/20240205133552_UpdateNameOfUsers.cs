using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Measure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameOfUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FemaleMeasures_User_UserId",
                table: "FemaleMeasures");

            migrationBuilder.DropForeignKey(
                name: "FK_MaleMeasures_User_UserId",
                table: "MaleMeasures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FemaleMeasures_Users_UserId",
                table: "FemaleMeasures",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaleMeasures_Users_UserId",
                table: "MaleMeasures",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FemaleMeasures_Users_UserId",
                table: "FemaleMeasures");

            migrationBuilder.DropForeignKey(
                name: "FK_MaleMeasures_Users_UserId",
                table: "MaleMeasures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FemaleMeasures_User_UserId",
                table: "FemaleMeasures",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaleMeasures_User_UserId",
                table: "MaleMeasures",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
