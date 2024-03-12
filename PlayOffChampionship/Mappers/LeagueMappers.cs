using PlayOffChampionship.Dtos.League;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Mappers
{
    public static class LeagueMappers
    {

        public static League ToLeagueFromCreateDto(this CreateLeagueDto createLeagueDto)
        {
            League league = new()
            {
                Name = createLeagueDto.Name,
                Description = createLeagueDto.Description
            };

            return league;
        }
    }
}
