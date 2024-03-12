using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Dtos;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Mappers;
using PlayOffChampionship.Models;

namespace PlayOffChampionship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {

        private ILeagueRepository _leagueRepository;


        public LeagueController(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeagues()
        {
            return Ok(await _leagueRepository.GetAllLeagues()); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLeagueDto leagueDto)
        {
            League leagueModel = leagueDto.ToLeagueFromCreateDto();

            var league = await _leagueRepository.Create(leagueModel);

            return Ok(league);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var league = await _leagueRepository.Delete(id);

            if (league == null)
            {
                return NotFound($"A league with the id: {id} does not exist");
            }

            return Ok(league);
        }
    }
}
