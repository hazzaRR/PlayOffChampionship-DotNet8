using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayOffChampionship.Migrations
{
    /// <inheritdoc />
    public partial class publicAndOwnerLeague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserLeague");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "league",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LeagueOwnerId",
                table: "league",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_league_LeagueOwnerId",
                table: "league",
                column: "LeagueOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LeagueId",
                table: "AspNetUsers",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_league_LeagueId",
                table: "AspNetUsers",
                column: "LeagueId",
                principalTable: "league",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_league_AspNetUsers_LeagueOwnerId",
                table: "league",
                column: "LeagueOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_league_LeagueId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_league_AspNetUsers_LeagueOwnerId",
                table: "league");

            migrationBuilder.DropIndex(
                name: "IX_league_LeagueOwnerId",
                table: "league");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LeagueId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "league");

            migrationBuilder.DropColumn(
                name: "LeagueOwnerId",
                table: "league");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "AspNetUsers");

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
        }
    }
}
