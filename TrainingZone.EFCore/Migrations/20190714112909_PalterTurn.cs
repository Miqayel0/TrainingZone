using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingZone.EFCore.Migrations
{
    public partial class PalterTurn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turn",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "FirstPlayerTurn",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstPlayerTurn",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Turn",
                table: "Games",
                nullable: true);
        }
    }
}
