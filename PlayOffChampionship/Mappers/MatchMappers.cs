using PlayOffChampionship.Dtos;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Mappers
{
    public static class MatchMappers
    {

        public static Match ToMatchFromCreateMatchDto(this CreateMatchDto matchDto, ApplicationUser player1, ApplicationUser player2, League league, ApplicationUser winner)
        {

            Match match = new()
            {
                MatchDate = matchDto.MatchDate,
                Player1 = player1,
                Player2 = player2,
                Player1Score = matchDto.Player1Score,
                Player2Score = matchDto.Player2Score,
                League = league,
                Winner = winner
            };

            return match;

        }

        public static MatchDto ToMatchDtoFromMatch(this Match match)
        {
            MatchDto matchDto = new()
            {
                Id = match.Id,
                MatchDate = match.MatchDate,
                Player1 = match.Player1.ToPlayerDtoFromPlayer(),
                Player2 = match.Player2.ToPlayerDtoFromPlayer(),
                Player1Score = match.Player1Score,
                Player2Score = match.Player2Score,
                League = match.League.ToLeagueDtoFromLeague(),
                Winner = match.Winner.ToPlayerDtoFromPlayer(),
                LeagueId = match.LeagueId,
                Player1Id = match.Player1Id,
                Player2Id = match.Player2Id,
                WinnerId = match.WinnerId
            };

            return matchDto;
        }
    }
}
