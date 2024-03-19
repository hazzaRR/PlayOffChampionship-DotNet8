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

        public async Task<Leaderboard> Create(Leaderboard leaderboard)
        {
            var leaderboardRecord = _context.Leaderboard.Add(leaderboard);
            await _context.SaveChangesAsync();

            return leaderboard;
        }

        public async Task<List<Leaderboard>> GetByLeagueId(int leagueId)
        {
            var leaderboard = await _context.Leaderboard.Where(row => row.LeagueId == leagueId).OrderBy(row => row.TotalWins).Include(match => match.Player).Include(match => match.League).ToListAsync();

            return leaderboard;
        }

        public Task<Leaderboard?> GetByLeagueIdAndPlayerId(int leagueId, int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<Leaderboard> Update(Leaderboard leaderboard)
        {
            throw new NotImplementedException();
        }

        public Task<Leaderboard> UpdateLeaderboard(Leaderboard leaderboard)
        {
            throw new NotImplementedException();
        }
    }
}
