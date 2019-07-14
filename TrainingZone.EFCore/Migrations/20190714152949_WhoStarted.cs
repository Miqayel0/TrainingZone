using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingZone.EFCore.Migrations
{
    public partial class WhoStarted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WhoHasStarted",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhoHasStarted",
                table: "Games");
        }
    }
}
