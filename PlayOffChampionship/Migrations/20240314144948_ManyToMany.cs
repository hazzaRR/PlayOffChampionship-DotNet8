using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayOffChampionship.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_player_league_LeagueId",
                table: "player");

            migrationBuilder.DropIndex(
                name: "IX_player_LeagueId",
                table: "player");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "player");

            migrationBuilder.CreateTable(
                name: "LeaguePlayer",
                columns: table => new
                {
                    LeaguesId = table.Column<int>(type: "integer", nullable: false),
                    PlayersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaguePlayer", x => new { x.LeaguesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_LeaguePlayer_league_LeaguesId",
                        column: x => x.LeaguesId,
                        principalTable: "league",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaguePlayer_player_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_league",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    LeagueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_league", x => new { x.PlayerId, x.LeagueId });
                    table.ForeignKey(
                        name: "FK_player_league_league_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "league",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_player_league_player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaguePlayer_PlayersId",
                table: "LeaguePlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_player_league_LeagueId",
                table: "player_league",
                column: "LeagueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaguePlayer");

            migrationBuilder.DropTable(
                name: "player_league");

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "player",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_player_LeagueId",
                table: "player",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_player_league_LeagueId",
                table: "player",
                column: "LeagueId",
                principalTable: "league",
                principalColumn: "Id");
        }
    }
}
