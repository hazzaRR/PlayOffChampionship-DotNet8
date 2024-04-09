using PlayOffChampionship.Dtos;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Mappers
{
    public static class LeaderboardMappers
    {

        public static LeaderboardDto ToLeaderboardDtoFromLeaderboard(this Leaderboard leaderboard)
        {
            LeaderboardDto leaderboardDto = new()
            {
                Id = leaderboard.Id,
                LeagueId = leaderboard.LeagueId,
                PlayerId = leaderboard.PlayerId,
                TotalMatches = leaderboard.TotalMatches,
                TotalWins = leaderboard.TotalWins,
                Points = leaderboard.Points,
                PlayerDto = leaderboard.Player.ToPlayerDtoFromPlayer(),
                LeagueDto = leaderboard.League.ToLeagueDtoFromLeague()

            };

            return leaderboardDto;
        }
    }

}
