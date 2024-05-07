using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Mappers;
using System.Security.Claims;

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


        [Authorize]
        [HttpGet("league/{id}/player")]
        public async Task<IActionResult> GetByLeagueIdAndPlayer([FromRoute] int id)

        {

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound("No user is successfully logged in");
            }

            var leaderboard = await _leaderboardRepository.GetByLeagueIdAndPlayerId(id, userId);

            if (leaderboard == null)
            {
                return NotFound();
            }

            return Ok(leaderboard.ToLeaderboardDtoFromLeaderboard());
        }
    }
}
