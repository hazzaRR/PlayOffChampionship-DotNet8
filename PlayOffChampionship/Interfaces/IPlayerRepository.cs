using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface IPlayerRepository
    {

        Task<List<ApplicationUser>> GetAllPlayers();
        Task<ApplicationUser?> GetPlayerById(int id);
        Task<ApplicationUser> Create(ApplicationUser player);
        Task<ApplicationUser?> Update(int id, ApplicationUser player);
        Task<ApplicationUser?> Delete(int id);


    }
}
