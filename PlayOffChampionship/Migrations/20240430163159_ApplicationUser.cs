using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayOffChampionship.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaderboard_player_PlayerId",
                table: "leaderboard");

            migrationBuilder.DropForeignKey(
                name: "FK_match_player_Player1Id",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_player_Player2Id",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_player_WinnerId",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_player_league_player_PlayerId",
                table: "player_league");

            migrationBuilder.DropTable(
                name: "LeaguePlayer");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "player_league",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "WinnerId",
                table: "match",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Player2Id",
                table: "match",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Player1Id",
                table: "match",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "leaderboard",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserLeague",
                columns: table => new
                {
                    LeaguesId = table.Column<int>(type: "integer", nullable: false),
                    PlayersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLeague", x => new { x.LeaguesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserLeague_AspNetUsers_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserLeague_league_LeaguesId",
                        column: x => x.LeaguesId,
                        principalTable: "league",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserLeague_PlayersId",
                table: "ApplicationUserLeague",
                column: "PlayersId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaderboard_AspNetUsers_PlayerId",
                table: "leaderboard",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_AspNetUsers_Player1Id",
                table: "match",
                column: "Player1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_AspNetUsers_Player2Id",
                table: "match",
                column: "Player2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_AspNetUsers_WinnerId",
                table: "match",
                column: "WinnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_player_league_AspNetUsers_PlayerId",
                table: "player_league",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaderboard_AspNetUsers_PlayerId",
                table: "leaderboard");

            migrationBuilder.DropForeignKey(
                name: "FK_match_AspNetUsers_Player1Id",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_AspNetUsers_Player2Id",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_AspNetUsers_WinnerId",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_player_league_AspNetUsers_PlayerId",
                table: "player_league");

            migrationBuilder.DropTable(
                name: "ApplicationUserLeague");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "player_league",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "match",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Player2Id",
                table: "match",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Player1Id",
                table: "match",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "leaderboard",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaguePlayer_PlayersId",
                table: "LeaguePlayer",
                column: "PlayersId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaderboard_player_PlayerId",
                table: "leaderboard",
                column: "PlayerId",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_player_Player1Id",
                table: "match",
                column: "Player1Id",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_player_Player2Id",
                table: "match",
                column: "Player2Id",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_player_WinnerId",
                table: "match",
                column: "WinnerId",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_player_league_player_PlayerId",
                table: "player_league",
                column: "PlayerId",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
