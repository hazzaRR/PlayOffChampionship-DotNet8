using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Repository
{
    public class MatchRepository : IMatchRepository
    {

        private readonly AppDbContext _context;

        public MatchRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Match> Create(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return match;

        }

        public Task<Match?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Match?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Match?> GetByLeagueId(int leagueId)
        {
            throw new NotImplementedException();
        }

        public Task<Match?> GetByPlayerId(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<Match?> GetByWinnerId(int winnerId)
        {
            throw new NotImplementedException();
        }

        public Task<Match?> Update(int id, Match match)
        {
            throw new NotImplementedException();
        }
    }
}
