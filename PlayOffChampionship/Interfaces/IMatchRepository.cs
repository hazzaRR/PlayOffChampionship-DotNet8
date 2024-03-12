using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface IMatchRepository
    {

        Task<Match?> GetById(int id);

        Task<Match?> GetByLeagueId(int leagueId);

        Task<Match?> GetByPlayerId(int playerId);

        Task<Match?> GetByWinnerId(int winnerId);

        Task<Match> Create(Match match);

        Task<Match?> Update(int id, Match match);

        Task<Match?> Delete(int id);


    }
}
