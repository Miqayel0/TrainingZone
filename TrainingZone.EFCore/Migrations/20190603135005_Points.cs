using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingZone.EFCore.Migrations
{
    public partial class Points : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Point_PointId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Games_GameId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_AspNetUsers_PlayerId",
                table: "Point");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Point",
                table: "Point");

            migrationBuilder.RenameTable(
                name: "Point",
                newName: "Coordinates");

            migrationBuilder.RenameIndex(
                name: "IX_Point_PlayerId",
                table: "Coordinates",
                newName: "IX_Coordinates_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_GameId",
                table: "Coordinates",
                newName: "IX_Coordinates_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Games_GameId",
                table: "Coordinates",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_AspNetUsers_PlayerId",
                table: "Coordinates",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Coordinates_PointId",
                table: "Games",
                column: "PointId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Games_GameId",
                table: "Coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_AspNetUsers_PlayerId",
                table: "Coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Coordinates_PointId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates");

            migrationBuilder.RenameTable(
                name: "Coordinates",
                newName: "Point");

            migrationBuilder.RenameIndex(
                name: "IX_Coordinates_PlayerId",
                table: "Point",
                newName: "IX_Point_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Coordinates_GameId",
                table: "Point",
                newName: "IX_Point_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Point",
                table: "Point",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Point_PointId",
                table: "Games",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Games_GameId",
                table: "Point",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_AspNetUsers_PlayerId",
                table: "Point",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
