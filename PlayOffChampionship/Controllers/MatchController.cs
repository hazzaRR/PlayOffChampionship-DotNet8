using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayOffChampionship.Interfaces;

namespace PlayOffChampionship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {

        private readonly IMatchRepository _matchRepository;

        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }   
    }
}
