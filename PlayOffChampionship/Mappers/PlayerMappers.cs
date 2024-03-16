using PlayOffChampionship.Dtos;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Mappers
{
    public static class PlayerMappers
    {

        public static Player ToPlayerFromPlayerDto(this PlayerDto playerDto)
        {
            Player player = new()
            {
                Name = playerDto.Name
            };

            return player;
        }

        public static PlayerDto ToPlayerDtoFromPlayer(this Player player)
        {
            PlayerDto playerDto = new()
            {
                Name = player.Name
            };

            return playerDto;
        }
    }
}
