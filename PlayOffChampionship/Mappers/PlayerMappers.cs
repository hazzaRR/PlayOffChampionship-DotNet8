using PlayOffChampionship.Dtos.Players;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Mappers
{
    public static class PlayerMappers
    {

        public static Player ToPlayerDtoFromPlayer(this PlayerDto playerDto)
        {
            Player player = new()
            {
                Name = playerDto.Name
            };

            return player;
        }
    }
}
