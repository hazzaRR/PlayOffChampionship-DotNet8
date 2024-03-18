using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface IPlayerLeagueRepository
    {

        Task<PlayerLeague> Create(PlayerLeague playerLeague);
    }
}
