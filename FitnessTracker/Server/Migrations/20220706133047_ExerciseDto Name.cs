using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessTracker.Server.Migrations
{
    public partial class ExerciseDtoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExerciseDto",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExerciseDto");
        }
    }
}
