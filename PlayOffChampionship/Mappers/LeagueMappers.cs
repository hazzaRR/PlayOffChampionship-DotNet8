using PlayOffChampionship.Dtos.League;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Mappers
{
    public static class LeagueMappers
    {

        public static League ToLeagueFromLeagueDto(this LeagueDto leagueDto)
        {
            League league = new()
            {
                Name = leagueDto.Name,
                Description = leagueDto.Description
            };

            return league;
        }

        public static LeagueDto ToLeagueDtoFromLeague(this League league)
        {
            LeagueDto leagueDto = new()
            {
                Name = league.Name,
                Description = league.Description
            };

            return leagueDto;
        }
    }
}
