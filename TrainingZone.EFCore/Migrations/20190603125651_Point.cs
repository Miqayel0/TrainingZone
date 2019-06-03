using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingZone.EFCore.Migrations
{
    public partial class Point : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    GameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Point_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ScoreId = table.Column<int>(nullable: false),
                    FirstPlayerId = table.Column<string>(nullable: true),
                    SecondPlayerId = table.Column<string>(nullable: true),
                    MatrixSize = table.Column<int>(nullable: false),
                    FirstPlayerTurnType = table.Column<string>(nullable: false),
                    SecondPlayerTurnType = table.Column<string>(nullable: false),
                    FirstPlayedPlayer = table.Column<int>(nullable: true),
                    IsGameStarted = table.Column<bool>(nullable: false),
                    IsGameFinished = table.Column<bool>(nullable: false),
                    PointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_FirstPlayerId",
                        column: x => x.FirstPlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Games_Point_PointId",
                        column: x => x.PointId,
                        principalTable: "Point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Scores_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Scores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_SecondPlayerId",
                        column: x => x.SecondPlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_FirstPlayerId",
                table: "Games",
                column: "FirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PointId",
                table: "Games",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ScoreId",
                table: "Games",
                column: "ScoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_SecondPlayerId",
                table: "Games",
                column: "SecondPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Point_GameId",
                table: "Point",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Point_PlayerId",
                table: "Point",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Games_GameId",
                table: "Point",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Point_PointId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
