using Microsoft.EntityFrameworkCore;
using PlayOffChampionship.Dtos;
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
        public async Task<League> Create(League league)
        {
            _context.Leagues.Add(league);
            await _context.SaveChangesAsync();
            return league;
        }

        public async Task<League?> Delete(int id)
        {
            League? league = await _context.Leagues.FirstOrDefaultAsync(league => league.Id == id);

            if (league == null)
            {
                return null;
            }

            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();

            return league;
        }

        public async Task<List<League>> GetAllLeagues()
        {
            return await _context.Leagues.ToListAsync();
        }

        public async Task<League?> GetLeagueById(int id)
        {
            return await _context.Leagues.FirstOrDefaultAsync(league=>league.Id == id);

        }

        public async Task<League?> Update(int id, LeagueDto leagueDto)
        {
            League? leagueModel = await  _context.Leagues.FirstOrDefaultAsync(league => league.Id == id);

            if (leagueModel == null)
            {
                return null;
            }

            leagueModel.Name = leagueDto.Name;
            leagueModel.Description = leagueDto.Description;

            await _context.SaveChangesAsync();

            return leagueModel;
        }
    }
}
