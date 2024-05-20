using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface IPlayerLeagueRepository
    {

        Task<PlayerLeague> Create(PlayerLeague playerLeague);
        Task<bool> JoinLeague(ApplicationUser player, League league);

        Task<List<League>> GetAllPlayerLeagues(string userId);

        Task<List<League>> GetAllLeaguesNotJoinedByPlayer(string userId);
    }
}
