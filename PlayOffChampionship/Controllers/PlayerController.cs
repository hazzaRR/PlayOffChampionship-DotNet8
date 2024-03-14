using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Dtos.Players;
using PlayOffChampionship.Models;
using PlayOffChampionship.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PlayOffChampionship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerRepository _playerRepository;   

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _playerRepository.GetAllPlayers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var player = await _playerRepository.GetPlayerById(id);

            if (player == null)
            {
                return NotFound($"Player with the id: {id} does not exist");
            }

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlayerDto playerDto)
        {
            Player player = playerDto.ToPlayerDtoFromPlayer();

            var playerModel = await _playerRepository.Create(player);

            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var player = await _playerRepository.Delete(id);

            if (player == null)
            {
                return NotFound($"Player with the id: {id} does not exist");
            }

            return Ok(player);
        }

    }
}
