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

        public async Task<ApplicationUser> Create(ApplicationUser player)
        {
            _context.Users.Add(player);

            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<ApplicationUser?> Delete(string id)
        {
            var player = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);

            if (player == null)
            {
                return null;
            }

            _context.Users.Remove(player);

            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<List<ApplicationUser>> GetAllPlayers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser?> GetPlayerById(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<ApplicationUser?> Update(string id, ApplicationUser player)
        {
            throw new NotImplementedException();
        }
    }
}
