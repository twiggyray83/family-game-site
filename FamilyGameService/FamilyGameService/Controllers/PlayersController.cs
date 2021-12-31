using FamilyGameService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FamilyGameService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;

        public PlayersController(ILogger<PlayersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<GetUserResponse> Get()
        {
            var users = new List<GetUserResponse>();
            users.Add(new GetUserResponse() { Id = 1, PlayerName = "hello" });
            return users;
        }
    }
}