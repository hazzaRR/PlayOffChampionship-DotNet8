using PlayOffChampionship.Dtos;
using PlayOffChampionship.Models;
using System.Reflection;

namespace PlayOffChampionship.Interfaces
{
    public interface IMatchRepository
    {

        Task<Match?> GetById(int id);

        Task<List<Match>> GetByLeagueId(int leagueId);

        Task<List<Match>> GetByPlayerId(string playerId);

        Task<List<Match>> GetByWinnerId(string winnerId);

        Task<Match> Create(CreateMatchDto createMatchDto, ApplicationUser player1, ApplicationUser player2, League league, ApplicationUser winner);

        Task<Match?> Update(int id, MatchDto match);

        Task<Match?> Delete(int id);


    }
}
