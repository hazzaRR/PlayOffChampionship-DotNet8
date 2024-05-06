﻿using Microsoft.AspNetCore.Authorization;
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
                return BadRequest();
            }

            return Created();
        }


    }
}
