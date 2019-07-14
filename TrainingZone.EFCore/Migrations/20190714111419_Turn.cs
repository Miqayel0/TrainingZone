using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingZone.EFCore.Migrations
{
    public partial class Turn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstPlayerTurnType",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SecondPlayerTurnType",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "WhoIsStarts",
                table: "Games",
                newName: "Turn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Turn",
                table: "Games",
                newName: "WhoIsStarts");

            migrationBuilder.AddColumn<string>(
                name: "FirstPlayerTurnType",
                table: "Games",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondPlayerTurnType",
                table: "Games",
                nullable: false,
                defaultValue: "");
        }
    }
}
