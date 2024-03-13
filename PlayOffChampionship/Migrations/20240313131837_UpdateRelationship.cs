using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayOffChampionship.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaderboard_Leagues_LeagueId",
                table: "Leaderboard");

            migrationBuilder.DropForeignKey(
                name: "FK_Leaderboard_Players_PlayerId",
                table: "Leaderboard");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Leagues_LeagueId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_Player1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_Player2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_WinnerId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leaderboard",
                table: "Leaderboard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues");

            migrationBuilder.RenameTable(
                name: "Leaderboard",
                newName: "leaderboard");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "player");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "match");

            migrationBuilder.RenameTable(
                name: "Leagues",
                newName: "league");

            migrationBuilder.RenameIndex(
                name: "IX_Leaderboard_PlayerId",
                table: "leaderboard",
                newName: "IX_leaderboard_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Leaderboard_LeagueId",
                table: "leaderboard",
                newName: "IX_leaderboard_LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_WinnerId",
                table: "match",
                newName: "IX_match_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_Player2Id",
                table: "match",
                newName: "IX_match_Player2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_Player1Id",
                table: "match",
                newName: "IX_match_Player1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_LeagueId",
                table: "match",
                newName: "IX_match_LeagueId");

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "player",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_leaderboard",
                table: "leaderboard",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_player",
                table: "player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_match",
                table: "match",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_league",
                table: "league",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_player_LeagueId",
                table: "player",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaderboard_league_LeagueId",
                table: "leaderboard",
                column: "LeagueId",
                principalTable: "league",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leaderboard_player_PlayerId",
                table: "leaderboard",
                column: "PlayerId",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_league_LeagueId",
                table: "match",
                column: "LeagueId",
                principalTable: "league",
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
                name: "FK_player_league_LeagueId",
                table: "player",
                column: "LeagueId",
                principalTable: "league",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaderboard_league_LeagueId",
                table: "leaderboard");

            migrationBuilder.DropForeignKey(
                name: "FK_leaderboard_player_PlayerId",
                table: "leaderboard");

            migrationBuilder.DropForeignKey(
                name: "FK_match_league_LeagueId",
                table: "match");

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
                name: "FK_player_league_LeagueId",
                table: "player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_leaderboard",
                table: "leaderboard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_player",
                table: "player");

            migrationBuilder.DropIndex(
                name: "IX_player_LeagueId",
                table: "player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_match",
                table: "match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_league",
                table: "league");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "player");

            migrationBuilder.RenameTable(
                name: "leaderboard",
                newName: "Leaderboard");

            migrationBuilder.RenameTable(
                name: "player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "match",
                newName: "Matches");

            migrationBuilder.RenameTable(
                name: "league",
                newName: "Leagues");

            migrationBuilder.RenameIndex(
                name: "IX_leaderboard_PlayerId",
                table: "Leaderboard",
                newName: "IX_Leaderboard_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_leaderboard_LeagueId",
                table: "Leaderboard",
                newName: "IX_Leaderboard_LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_match_WinnerId",
                table: "Matches",
                newName: "IX_Matches_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_match_Player2Id",
                table: "Matches",
                newName: "IX_Matches_Player2Id");

            migrationBuilder.RenameIndex(
                name: "IX_match_Player1Id",
                table: "Matches",
                newName: "IX_Matches_Player1Id");

            migrationBuilder.RenameIndex(
                name: "IX_match_LeagueId",
                table: "Matches",
                newName: "IX_Matches_LeagueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leaderboard",
                table: "Leaderboard",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaderboard_Leagues_LeagueId",
                table: "Leaderboard",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leaderboard_Players_PlayerId",
                table: "Leaderboard",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Leagues_LeagueId",
                table: "Matches",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_Player1Id",
                table: "Matches",
                column: "Player1Id",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_Player2Id",
                table: "Matches",
                column: "Player2Id",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
