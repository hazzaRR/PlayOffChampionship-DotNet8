using PlayOffChampionship.Dtos;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface ILeagueRepository
    {

        Task<List<League>> GetAllLeagues();

        Task<League?> GetLeagueById(int id);

        Task<League> Create(League league);
        Task<League?> Update(int id, LeagueDto leagueDto);

        Task<League?> Delete(int id);




    }
}
