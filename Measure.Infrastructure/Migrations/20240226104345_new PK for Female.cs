using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Measure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newPKforFemale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FemaleMeasures",
                table: "FemaleMeasures");

            migrationBuilder.DropIndex(
                name: "IX_FemaleMeasures_UserId",
                table: "FemaleMeasures");

            migrationBuilder.DropColumn(
                name: "FemaleMeasureId",
                table: "FemaleMeasures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FemaleMeasures",
                table: "FemaleMeasures",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FemaleMeasures",
                table: "FemaleMeasures");

            migrationBuilder.AddColumn<Guid>(
                name: "FemaleMeasureId",
                table: "FemaleMeasures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FemaleMeasures",
                table: "FemaleMeasures",
                column: "FemaleMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_FemaleMeasures_UserId",
                table: "FemaleMeasures",
                column: "UserId",
                unique: true);
        }
    }
}
