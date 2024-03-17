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
        public Task<PlayerLeague> Create(Player player, League league)
        {
            throw new NotImplementedException();
        }
    }
}
