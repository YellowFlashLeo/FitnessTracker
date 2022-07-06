using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessTracker.Server.Migrations
{
    public partial class AddedDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingDaysDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trained = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDaysDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MuscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    RPE = table.Column<int>(type: "int", nullable: false),
                    TrainingDayDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseDto_TrainingDaysDto_TrainingDayDtoId",
                        column: x => x.TrainingDayDtoId,
                        principalTable: "TrainingDaysDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FoodTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightGrams = table.Column<float>(type: "real", nullable: false),
                    CaloriesPer100 = table.Column<float>(type: "real", nullable: false),
                    FatsPer100 = table.Column<float>(type: "real", nullable: false),
                    CarbsPer100 = table.Column<float>(type: "real", nullable: false),
                    ProteinPer100 = table.Column<float>(type: "real", nullable: false),
                    TrainingDayDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDto_TrainingDaysDto_TrainingDayDtoId",
                        column: x => x.TrainingDayDtoId,
                        principalTable: "TrainingDaysDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDto_TrainingDayDtoId",
                table: "ExerciseDto",
                column: "TrainingDayDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDto_TrainingDayDtoId",
                table: "FoodDto",
                column: "TrainingDayDtoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseDto");

            migrationBuilder.DropTable(
                name: "FoodDto");

            migrationBuilder.DropTable(
                name: "TrainingDaysDto");
        }
    }
}
