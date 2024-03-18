using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Controllers
{
    [Route("api/player-league")]
    [ApiController]
    public class PlayerLeagueController : ControllerBase
    {

        private readonly IPlayerLeagueRepository _playerLeagueRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IPlayerRepository _playerRepository;

        public PlayerLeagueController(IPlayerLeagueRepository playerLeagueRepository, ILeagueRepository leagueRepository, IPlayerRepository playerRepository)
        {
            _playerLeagueRepository = playerLeagueRepository;
            _leagueRepository = leagueRepository;
            _playerRepository = playerRepository;
        }

        [HttpPost("join/{id}/player/{playerId}")]
        public async Task<IActionResult> Create([FromRoute] int id, [FromRoute] int playerId)
        {

            League? league = await _leagueRepository.GetLeagueById(id);

            if (league == null)
            {
                return NotFound($"A league with the id {id} does not exist");
            }
            Player? player = await _playerRepository.GetPlayerById(playerId);
            if (player == null)
            {
                return NotFound($"A player with the id {id} does not exist");
            }

            PlayerLeague playerLeague = new()
            {
                Player = player,
                League = league
            };

            await _playerLeagueRepository.Create(playerLeague);

            return Created();
        }


    }
}
