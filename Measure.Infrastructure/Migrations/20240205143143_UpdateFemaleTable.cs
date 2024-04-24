using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Measure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFemaleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wrist",
                table: "FemaleMeasures",
                newName: "LegLenght");

            migrationBuilder.RenameColumn(
                name: "Thigh",
                table: "FemaleMeasures",
                newName: "HeadCircumference");

            migrationBuilder.RenameColumn(
                name: "ShoulderLength",
                table: "FemaleMeasures",
                newName: "HandCircumference");

            migrationBuilder.RenameColumn(
                name: "NapeWaist",
                table: "FemaleMeasures",
                newName: "FootWidth");

            migrationBuilder.RenameColumn(
                name: "MidShoulderBust",
                table: "FemaleMeasures",
                newName: "FingerCircumference");

            migrationBuilder.RenameColumn(
                name: "FrontRise",
                table: "FemaleMeasures",
                newName: "Calf");

            migrationBuilder.RenameColumn(
                name: "CrotchAnkle",
                table: "FemaleMeasures",
                newName: "BreastVolume");

            migrationBuilder.RenameColumn(
                name: "Biceps",
                table: "FemaleMeasures",
                newName: "ArmLenght");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LegLenght",
                table: "FemaleMeasures",
                newName: "Wrist");

            migrationBuilder.RenameColumn(
                name: "HeadCircumference",
                table: "FemaleMeasures",
                newName: "Thigh");

            migrationBuilder.RenameColumn(
                name: "HandCircumference",
                table: "FemaleMeasures",
                newName: "ShoulderLength");

            migrationBuilder.RenameColumn(
                name: "FootWidth",
                table: "FemaleMeasures",
                newName: "NapeWaist");

            migrationBuilder.RenameColumn(
                name: "FingerCircumference",
                table: "FemaleMeasures",
                newName: "MidShoulderBust");

            migrationBuilder.RenameColumn(
                name: "Calf",
                table: "FemaleMeasures",
                newName: "FrontRise");

            migrationBuilder.RenameColumn(
                name: "BreastVolume",
                table: "FemaleMeasures",
                newName: "CrotchAnkle");

            migrationBuilder.RenameColumn(
                name: "ArmLenght",
                table: "FemaleMeasures",
                newName: "Biceps");
        }
    }
}
