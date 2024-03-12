using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface ILeaderboardRepository
    {

       Task<Leaderboard> GetByLeagueId(int leagueId);
    }
}
