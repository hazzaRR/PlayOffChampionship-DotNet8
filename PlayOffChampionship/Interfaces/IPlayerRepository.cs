using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface IPlayerRepository
    {

        Task<List<Player>> GetAllPlayers();
        Task<Player?> GetPlayerById(int id);
        Task<Player> Create(Player player);
        Task<Player?> Update(int id, Player player);
        Task<Player?> Delete(int id);


    }
}
