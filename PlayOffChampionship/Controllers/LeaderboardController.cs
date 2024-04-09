using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Mappers;

namespace PlayOffChampionship.Controllers
{
    [Route("api/leaderboard")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {

        private readonly ILeaderboardRepository _leaderboardRepository;


        public LeaderboardController(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }


        [HttpGet("league/{id}")]
        public async Task<IActionResult> GetByLeagueId([FromRoute]int id)
        {
            var leaderboard = await _leaderboardRepository.GetByLeagueId(id);

            return Ok(leaderboard.Select(row => row.ToLeaderboardDtoFromLeaderboard()));
        }

        [HttpGet("league/{id}/player/{playerId}")]
        public async Task<IActionResult> GetByLeagueId([FromRoute] int id, [FromRoute] int playerId)
        {
            var leaderboard = await _leaderboardRepository.GetByLeagueIdAndPlayerId(id, playerId);

            if (leaderboard == null)
            {
                return NotFound();
            }

            return Ok(leaderboard.ToLeaderboardDtoFromLeaderboard());
        }
    }
}
