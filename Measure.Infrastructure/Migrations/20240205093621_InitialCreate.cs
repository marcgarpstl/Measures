using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Measure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FemaleMeasures",
                columns: table => new
                {
                    FemaleMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bust = table.Column<int>(type: "int", nullable: false),
                    Waist = table.Column<int>(type: "int", nullable: false),
                    Hip = table.Column<int>(type: "int", nullable: false),
                    NapeWaist = table.Column<int>(type: "int", nullable: false),
                    FrontRise = table.Column<int>(type: "int", nullable: false),
                    UnderBust = table.Column<int>(type: "int", nullable: false),
                    MidShoulderBust = table.Column<int>(type: "int", nullable: false),
                    ShoulderLength = table.Column<int>(type: "int", nullable: false),
                    Wrist = table.Column<int>(type: "int", nullable: false),
                    Biceps = table.Column<int>(type: "int", nullable: false),
                    CrotchAnkle = table.Column<int>(type: "int", nullable: false),
                    Thigh = table.Column<int>(type: "int", nullable: false),
                    FootLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FemaleMeasures", x => x.FemaleMeasureId);
                    table.ForeignKey(
                        name: "FK_FemaleMeasures_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaleMeasures",
                columns: table => new
                {
                    MaleMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Chest = table.Column<int>(type: "int", nullable: false),
                    Waist = table.Column<int>(type: "int", nullable: false),
                    Neck = table.Column<int>(type: "int", nullable: false),
                    ArmLength = table.Column<int>(type: "int", nullable: false),
                    Calf = table.Column<int>(type: "int", nullable: false),
                    Inseam = table.Column<int>(type: "int", nullable: false),
                    FootLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaleMeasures", x => x.MaleMeasureId);
                    table.ForeignKey(
                        name: "FK_MaleMeasures_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FemaleMeasures_UserId",
                table: "FemaleMeasures",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaleMeasures_UserId",
                table: "MaleMeasures",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FemaleMeasures");

            migrationBuilder.DropTable(
                name: "MaleMeasures");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
