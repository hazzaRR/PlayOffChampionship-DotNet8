using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;
using PlayOffChampionship.Dtos;
using PlayOffChampionship.Mappers;

namespace PlayOffChampionship.Controllers
{
    [Route("api/match")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var match = await _matchRepository.GetById(id);

            if (match == null)
            {
                return NotFound($"No match with the id: {id}");
            }

            return Ok(match.ToMatchDtoFromMatch());
        }

        [HttpGet("player/{id}")]
        public async Task<IActionResult> GetByPlayerId([FromRoute] string id)
        {
            var matches = await _matchRepository.GetByPlayerId(id);

            return Ok(matches.Select(match => match.ToMatchDtoFromMatch()));
        }


        [HttpGet("league/{id}")]
        public async Task<IActionResult> GetByLeagueId([FromRoute] int id)
        {
            var matches = await _matchRepository.GetByLeagueId(id);

            return Ok(matches.Select(match => match.ToMatchDtoFromMatch()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMatchDto createMatchDto)
        {

            ApplicationUser? player1 = await _playerRepository.GetPlayerById(createMatchDto.Player1Id);
            ApplicationUser? player2 = await _playerRepository.GetPlayerById(createMatchDto.Player2Id);
            League? league = await _leagueRepository.GetLeagueById(createMatchDto.LeagueId);
            ApplicationUser? winner = await _playerRepository.GetPlayerById(createMatchDto.WinnerId);

            if (player1 == null || player2 == null || league == null || winner == null)
            {
                return NotFound("one of the players or league supplied does not exist");
            }

            var match = await _matchRepository.Create(createMatchDto, player1, player2, league, winner);


            return Created(String.Empty, "Match created");
            
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            Match? match = await _matchRepository.Delete(id);
            
            if (match == null)
            {
                return NotFound($"match with ID: {id} does not exist");
            }

            return NoContent();

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, MatchDto matchDto)
        {

            Match? match = await _matchRepository.Update(id, matchDto);

            if (match == null)
            {
                return BadRequest("Error with the data passed");

            }

            return NoContent();
        }


    }
}
