using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Repository
{
    public class PlayerLeagueRepository : IPlayerLeagueRepository
    {

        private readonly AppDbContext _context;


        public PlayerLeagueRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PlayerLeague> Create(PlayerLeague playerLeague)
        {

            _context.PlayerLeagues.Add(playerLeague);
            await _context.SaveChangesAsync();

            return playerLeague;

        }
    }
}
