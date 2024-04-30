using PlayOffChampionship.Dtos;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Mappers
{
    public static class PlayerMappers
    {

        public static ApplicationUser ToPlayerFromPlayerDto(this PlayerDto playerDto)
        {
            ApplicationUser player = new()
            {
                Name = playerDto.Name
            };

            return player;
        }

        public static PlayerDto ToPlayerDtoFromPlayer(this ApplicationUser player)
        {
            PlayerDto playerDto = new()
            {
                Name = player.Name
            };

            return playerDto;
        }
    }
}
