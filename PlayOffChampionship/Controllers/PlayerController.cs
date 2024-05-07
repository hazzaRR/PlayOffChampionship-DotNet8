using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;
using PlayOffChampionship.Mappers;
using PlayOffChampionship.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Numerics;

namespace PlayOffChampionship.Controllers
{
    [Route("api/player")]
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

            var players = await _playerRepository.GetAllPlayers();

            return Ok(players.Select(player => player.ToPlayerDtoFromPlayer()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var player = await _playerRepository.GetPlayerById(id);

            if (player == null)
            {
                return NotFound($"Player with the id: {id} does not exist");
            }

            return Ok(player.ToPlayerDtoFromPlayer());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlayerDto playerDto)
        {
            ApplicationUser player = playerDto.ToPlayerFromPlayerDto();

            var playerModel = await _playerRepository.Create(player);

            return Created();
        }


        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound("No user is successfully logged in");
            }


            var player = await _playerRepository.Delete(userId);


            if (player == null)
            {
                return NotFound($"Player with the id: {userId} does not exist");
            }

            return Ok(player);
        }



        [Authorize]
        [HttpPut("set-details")]
        public async Task<IActionResult> setupUserDetails(PlayerDto playerDto)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound("No user is successfully logged in");
            }

            var playerModel = await _playerRepository.Update(userId, playerDto);


            return NoContent();
        }


    }
}
