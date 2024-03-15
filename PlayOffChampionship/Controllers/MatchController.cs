using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;
using PlayOffChampionship.Dtos;
using PlayOffChampionship.Mappers;

namespace PlayOffChampionship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {

        private readonly IMatchRepository _matchRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IPlayerRepository _playerRepository;

        public MatchController(IMatchRepository matchRepository, ILeagueRepository leagueRepository, IPlayerRepository playerRepository)
        {
            _matchRepository = matchRepository;
            _leagueRepository = leagueRepository;
            _playerRepository = playerRepository;
        }

        [HttpGet("player/{id}")]
        public async Task<IActionResult> GetByPlayerId([FromRoute] int id)
        {
            var matches = await _matchRepository.GetByPlayerId(id);

            return Ok(matches);
        }


        [HttpGet("league/{id}")]
        public async Task<IActionResult> GetByLeagueId([FromRoute] int id)
        {
            var matches = await _matchRepository.GetByLeagueId(id);

            return Ok(matches);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMatchDto createMatchDto)
        {

            Player? player1 = await _playerRepository.GetPlayerById(createMatchDto.Player1Id);
            Player? player2 = await _playerRepository.GetPlayerById(createMatchDto.Player2Id);
            League? league = await _leagueRepository.GetLeagueById(createMatchDto.LeagueId);
            Player? winner = await _playerRepository.GetPlayerById(createMatchDto.WinnerId);

            if (player1 == null || player2 == null || league == null || winner == null)
            {
                return NotFound("one of the players or league supplied doesnt not exist");
            }

            Match matchModel = createMatchDto.ToMatchFromCreateMatchDto(player1, player2, league, winner);
            var match = await _matchRepository.Create(matchModel);


            return Created();
        }



    }
}
