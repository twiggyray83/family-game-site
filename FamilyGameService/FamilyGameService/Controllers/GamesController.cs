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
        [HttpGet(Name = "GetGames")]
        public IEnumerable<GameResponse> Get()
        {
            using (var db = new postgresContext())
            {
                var players = new List<GameResponse>();
                return db.Games.Select(g => new GameResponse { Id = g.Id, Gamename = g.Gamename}).ToList();
            }
        }

        [HttpPost(Name = "CreateGame")]
        public int POST(string gameName)
        {
            var game = new Models.Game { Gamename = gameName };
            using (var db = new postgresContext())
            {
                db.Games.Add(game);
                db.SaveChanges();
                return game.Id;
            }
        }
    }
}
