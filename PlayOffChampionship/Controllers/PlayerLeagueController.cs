using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;

namespace PlayOffChampionship.Controllers
{
    [Route("api/player-league")]
    [ApiController]
    public class PlayerLeagueController : ControllerBase
    {

        private readonly IPlayerLeagueRepository _playerLeagueRepository;

        public PlayerLeagueController(IPlayerLeagueRepository playerLeagueRepository)
        {
            _playerLeagueRepository = playerLeagueRepository;
        }
    }
}
