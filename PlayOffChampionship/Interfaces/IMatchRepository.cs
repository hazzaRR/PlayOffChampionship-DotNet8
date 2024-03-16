using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface IMatchRepository
    {

        Task<Match?> GetById(int id);

        Task<List<Match>> GetByLeagueId(int leagueId);

        Task<List<Match>> GetByPlayerId(int playerId);

        Task<List<Match>> GetByWinnerId(int winnerId);

        Task<Match> Create(Match match);

        Task<Match?> Update(int id, Match match);

        Task<Match?> Delete(int id);


    }
}
