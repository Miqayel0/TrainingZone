using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingZone.EFCore.Migrations
{
    public partial class WhoIsstarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstPlayedPlayer",
                table: "Games",
                newName: "WhoIsStarts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WhoIsStarts",
                table: "Games",
                newName: "FirstPlayedPlayer");
        }
    }
}
