using PlayOffChampionship.Dtos;
using PlayOffChampionship.Models;
using System.Reflection;

namespace PlayOffChampionship.Interfaces
{
    public interface IMatchRepository
    {

        Task<Match?> GetById(int id);

        Task<List<Match>> GetByLeagueId(int leagueId);

        Task<List<Match>> GetByPlayerId(int playerId);

        Task<List<Match>> GetByWinnerId(int winnerId);

        Task<Match> Create(CreateMatchDto createMatchDto, Player player1, Player player2, League league, Player winner);

        Task<Match?> Update(int id, Match match);

        Task<Match?> Delete(int id);


    }
}
