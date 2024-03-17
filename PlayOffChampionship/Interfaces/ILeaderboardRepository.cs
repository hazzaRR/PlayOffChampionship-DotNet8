using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface ILeaderboardRepository
    {

       Task<List<Leaderboard>> GetByLeagueId(int leagueId);


        Task<Leaderboard?> GetLeaderboardByLeagueIdAndPlayerId(int leagueId, int  playerId);

        Task<Leaderboard> CreateLeaderboard(Leaderboard leaderboard);

        Task<Leaderboard> UpdateLeaderboard(Leaderboard leaderboard);
    }
}
