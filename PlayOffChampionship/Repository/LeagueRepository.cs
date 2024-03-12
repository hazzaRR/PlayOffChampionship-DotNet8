using Microsoft.EntityFrameworkCore;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Repository
{
    public class LeagueRepository : ILeagueRepository

    {
        private readonly AppDbContext _context;


        public LeagueRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<League> Create(League league)
        {
            throw new NotImplementedException();
        }

        public Task<League?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<League>> GetAllLeagues()
        {
            return await _context.Leagues.ToListAsync();
        }

        public Task<League?> GetLeagueById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<League?> Update(int id, League league)
        {
            throw new NotImplementedException();
        }
    }
}
