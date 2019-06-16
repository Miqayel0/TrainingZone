using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingZone.EFCore.Migrations
{
    public partial class Game : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Scores_ScoreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ScoreId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "ScoreId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Games_ScoreId",
                table: "Games",
                column: "ScoreId",
                unique: true,
                filter: "[ScoreId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Scores_ScoreId",
                table: "Games",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Scores_ScoreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ScoreId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "ScoreId",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ScoreId",
                table: "Games",
                column: "ScoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Scores_ScoreId",
                table: "Games",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
