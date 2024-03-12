using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;

namespace PlayOffChampionship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerRepository _playerRepository;   

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }   
    }
}
