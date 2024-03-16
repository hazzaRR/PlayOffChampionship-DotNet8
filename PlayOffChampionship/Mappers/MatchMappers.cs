using PlayOffChampionship.Dtos;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Mappers
{
    public static class MatchMappers
    {

        public static Match ToMatchFromCreateMatchDto(this CreateMatchDto matchDto, Player player1, Player player2, League league, Player winner)
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
    }
}
