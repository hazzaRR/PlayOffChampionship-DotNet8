using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> JoinLeague(ApplicationUser player, League league)
        {

            try
            {

                PlayerLeague playerLeague = new()
                {
                    Player = player,
                    League = league
                };

                //create record of player and leauge so that a player has offically joined a league
                _context.PlayerLeagues.Add(playerLeague);

                //create player's record of leaderboard in the given league

                Leaderboard leaderboard = new()
                {
                    League = league,
                    Player = player,
                    TotalMatches = 0,
                    TotalWins = 0
                };


                _context.Leaderboard.Add(leaderboard);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            
        }
    }
}
