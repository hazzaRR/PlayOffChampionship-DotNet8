using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;
using System.Security.Claims;

namespace PlayOffChampionship.Controllers
{
    [Route("api/player-league")]
    [ApiController]
    public class PlayerLeagueController : ControllerBase
    {

        private readonly IPlayerLeagueRepository _playerLeagueRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ILeaderboardRepository _leaderboardRepository;

        public PlayerLeagueController(IPlayerLeagueRepository playerLeagueRepository, ILeagueRepository leagueRepository, IPlayerRepository playerRepository, ILeaderboardRepository leaderboardRepository)
        {
            _playerLeagueRepository = playerLeagueRepository;
            _leagueRepository = leagueRepository;
            _playerRepository = playerRepository;
            _leaderboardRepository = leaderboardRepository;
        }

        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> GetPlayerLeagues()

        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound("No user is successfully logged in");
            }

            var leagues = await _playerLeagueRepository.GetAllPlayerLeagues(userId);

            if (leagues == null)
            {
                return NotFound();
            }

            return Ok(leagues);
        }


        [Authorize]
        [HttpGet("joinable")]
        public async Task<IActionResult> GetLeaguesPlayerNotApartOf()

        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound("No user is successfully logged in");
            }

            var leagues = await _playerLeagueRepository.GetAllLeaguesNotJoinedByPlayer(userId);

            if (leagues == null)
            {
                return NotFound();
            }

            return Ok(leagues);
        }



        [Authorize]
        [HttpPost("join/{id}")]
        public async Task<IActionResult> Create([FromRoute] int id)
        {

            string? userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return NotFound("No user is successfully logged in");
            }


            Console.WriteLine(userId);


            League? league = await _leagueRepository.GetLeagueById(id);

            if (league == null)
            {
                return NotFound($"A league with the id {id} does not exist");
            }

            ApplicationUser? player = await _playerRepository.GetPlayerById(userId);
            if (player == null)
            {
                return NotFound($"A player with the id {id} does not exist");
            }

            bool leaguePlayer = await _playerLeagueRepository.JoinLeague(player, league);

            if (!leaguePlayer)
            {
                return BadRequest("User already a member of the league");
            }

            return Created();
        }


    }
}
