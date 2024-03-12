using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface IPlayerRepository
    {


        List<Player> GetAllPlayers();

        Player GetPlayerById(int id);


    }
}
