using FamilyGameService.DTOs;
using FamilyGameService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyGameService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly postgresContext _context;

        public PlayersController(ILogger<PlayersController> logger, postgresContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<PlayerResponse> Get()
        {
            using (var db = _context)
            {
                var players = new List<PlayerResponse>();
                return db.Players.Select(p => new PlayerResponse { Id = p.Id, Playername = p.Playername }).ToList();
            }
        }

        [HttpPost(Name = "CreateUser")]
        public int POST(string playerName)
        {
            var player = new Models.Player { Playername = playerName };
            using (var db = _context)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return player.Id;
            }
        }


    }
}