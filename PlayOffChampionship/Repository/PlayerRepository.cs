using Microsoft.EntityFrameworkCore;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Repository
{
    public class PlayerRepository : IPlayerRepository
    {

        private readonly AppDbContext _context;
        public PlayerRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<Player> Create(Player player)
        {
            _context.Players.Add(player);

            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<Player?> Delete(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);

            if (player == null)
            {
                return null;
            }

            _context.Players.Remove(player);

            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player?> GetPlayerById(int id)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Player?> Update(int id, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
