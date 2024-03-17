using Microsoft.EntityFrameworkCore;
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

        public async Task<Match?> Delete(int id)
        {
            Match? match = await _context.Matches.FirstOrDefaultAsync(match => match.Id == id);

            if (match == null)
            {
                return null;
            }

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();

            return match;
        }

        public async Task<Match?> GetById(int id)
        {
            var match = await _context.Matches
                .Include(match => match.Player1)
                .Include(match => match.Player2)
                .Include(match => match.League)
                .Include(match => match.Winner)
                .FirstOrDefaultAsync(match => match.Id == id);

            if (match == null)
            {
                return null;
            }

            return match;
        }

        public async Task<List<Match>> GetByLeagueId(int leagueId)
        {
                 var matches = await _context.Matches
                .Include(match => match.Player1)
                .Include(match => match.Player2)
                .Include(match => match.League)
                .Include(match => match.Winner)
                .Where(match => match.LeagueId == leagueId)
                .ToListAsync();


                return matches;
            }

        public async Task<List<Match>> GetByPlayerId(int playerId)
        {
            var matches = await _context.Matches
            .Include(match => match.Player1)
            .Include(match => match.Player2)
            .Include(match => match.League)
            .Include(match => match.Winner)
            .Where(match => match.Player1Id == playerId || match.Player2Id == playerId)
            .ToListAsync();


            return matches;
        }

        public async Task<List<Match>> GetByWinnerId(int winnerId)
        {
            var matches = await _context.Matches
            .Include(match => match.Player1)
            .Include(match => match.Player2)
            .Include(match => match.League)
            .Include(match => match.Winner)
            .Where(match => match.WinnerId == winnerId)
            .ToListAsync();


            return matches;
        }

        public Task<Match?> Update(int id, Match match)
        {
            throw new NotImplementedException();
        }
    }
}
