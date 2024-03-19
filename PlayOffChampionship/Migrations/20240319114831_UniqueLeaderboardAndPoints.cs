using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayOffChampionship.Migrations
{
    /// <inheritdoc />
    public partial class UniqueLeaderboardAndPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_leaderboard_PlayerId",
                table: "leaderboard");

            migrationBuilder.CreateIndex(
                name: "IX_leaderboard_PlayerId_LeagueId",
                table: "leaderboard",
                columns: new[] { "PlayerId", "LeagueId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_leaderboard_PlayerId_LeagueId",
                table: "leaderboard");

            migrationBuilder.CreateIndex(
                name: "IX_leaderboard_PlayerId",
                table: "leaderboard",
                column: "PlayerId");
        }
    }
}
