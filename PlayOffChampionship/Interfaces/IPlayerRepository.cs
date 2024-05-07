using PlayOffChampionship.Dtos;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface IPlayerRepository
    {

        Task<List<ApplicationUser>> GetAllPlayers();
        Task<ApplicationUser?> GetPlayerById(string id);
        Task<ApplicationUser> Create(ApplicationUser player);
        Task<ApplicationUser?> Update(string id, PlayerDto playerDto);
        Task<ApplicationUser?> Delete(string id);


    }
}
