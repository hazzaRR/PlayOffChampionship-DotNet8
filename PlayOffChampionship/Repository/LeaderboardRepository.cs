using Microsoft.EntityFrameworkCore;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Repository
{
    public class LeaderboardRepository : ILeaderboardRepository
    {

        private readonly AppDbContext _context;

        public LeaderboardRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Leaderboard>> GetByLeagueId(int leagueId)
        {
            var leaderboard = await _context.Leaderboard.Where(row => row.LeagueId == leagueId).OrderBy(row => row.TotalWins).ToListAsync();

            return leaderboard;
        }
    }
}
