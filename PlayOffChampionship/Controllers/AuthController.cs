using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayOffChampionship.Models;
using System.Security.Claims;

namespace PlayOffChampionship.Controllers
{

    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly AppDbContext _context;
        private readonly HttpContext _httpContext;



        public AuthController(AppDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext.HttpContext;
        }



        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            //string? userId = _principal.Claims.FirstOrDefault(claims => claims.Type == ClaimTypes.NameIdentifier).Value;

            string? userId = _httpContext.User.Claims.FirstOrDefault(claims => claims.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return NotFound("No user is successfully logged in");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);


            return Ok(user);
        }
    }
}
