using FamilyGameService.DTOs;
using FamilyGameService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyGameService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly postgresContext _context;
        
        public GamesController(postgresContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetGames")]
        public IEnumerable<GameResponse> Get()
        {
            using (var db = _context)
            {
                var players = new List<GameResponse>();
                return db.Games.Select(g => new GameResponse { Id = g.Id, Gamename = g.Gamename}).ToList();
            }
        }

        [HttpPost(Name = "CreateGame")]
        public int POST([FromBody] string gameName)
        {
            var game = new Models.Game { Gamename = gameName };
            using (var db = _context)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return game.Id;
            }
        }
    }
}
