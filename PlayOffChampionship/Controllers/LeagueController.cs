﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Dtos;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Mappers;
using PlayOffChampionship.Models;
using PlayOffChampionship.Repository;
using System.Security.Claims;

namespace PlayOffChampionship.Controllers
{
    [Route("api/league")]
    [ApiController]
    public class LeagueController : ControllerBase
    {

        private ILeagueRepository _leagueRepository;


        public LeagueController(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllLeagues()
        {

            var leagues = await _leagueRepository.GetAllLeagues();
            return Ok(leagues.Select(league => league.ToLeagueDtoFromLeague())); 
        }


    [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var league = await _leagueRepository.GetLeagueById(id);

            if (league == null) 
            {
                return NotFound($"A league with the id: {id} does not exist");
            }

            return Ok(league.ToLeagueDtoFromLeague());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeagueDto leagueDto)
        {
            League leagueModel = leagueDto.ToLeagueFromLeagueDto();

            var league = await _leagueRepository.Create(leagueModel);

            return Ok(league.ToLeagueDtoFromLeague());


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var league = await _leagueRepository.Delete(id);

            if (league == null)
            {
                return NotFound($"A league with the id: {id} does not exist");
            }

            return Ok(league.ToLeagueDtoFromLeague());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody]  LeagueDto leagueDto)
        {
            var league = await _leagueRepository.Update(id, leagueDto);

            if ( league == null)
            {
                return NotFound($"League could not be updated. No league with the id: {id} was found");
            }

            return Ok(league.ToLeagueDtoFromLeague());
        }



    }
}
