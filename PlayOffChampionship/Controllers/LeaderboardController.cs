﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;

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

            return Ok(leaderboard);
        }
    }
}
