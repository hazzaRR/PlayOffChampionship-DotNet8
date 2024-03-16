using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayOffChampionship.Migrations
{
    /// <inheritdoc />
    public partial class MatchScores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Player1Score",
                table: "match",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player2Score",
                table: "match",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Player1Score",
                table: "match");

            migrationBuilder.DropColumn(
                name: "Player2Score",
                table: "match");
        }
    }
}
