using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingZone.EFCore.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WhoHasStarted",
                table: "Games",
                newName: "SecondPlayerTurn");

            migrationBuilder.RenameColumn(
                name: "Y",
                table: "Coordinates",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "X",
                table: "Coordinates",
                newName: "CoordinateY");

            migrationBuilder.AddColumn<int>(
                name: "CoordinateX",
                table: "Coordinates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinateX",
                table: "Coordinates");

            migrationBuilder.RenameColumn(
                name: "SecondPlayerTurn",
                table: "Games",
                newName: "WhoHasStarted");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Coordinates",
                newName: "Y");

            migrationBuilder.RenameColumn(
                name: "CoordinateY",
                table: "Coordinates",
                newName: "X");
        }
    }
}
