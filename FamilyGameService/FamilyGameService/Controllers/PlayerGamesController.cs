using FamilyGameService.DTOs;
using FamilyGameService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyGameService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerGamessController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly postgresContext _context;

        public PlayerGamessController(ILogger<PlayersController> logger, postgresContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetStatsByPlayer")]
        public IEnumerable<GetPlayerStatsResponse> GET(int playerId)
        {
            using (var db = _context)
            {
                return (from pg in db.Playergames
                        join g in db.Games
                        on pg.Gameid equals g.Id
                        where pg.Playerid == playerId
                        group pg by g.Gamename into g2
                        select new GetPlayerStatsResponse
                        {
                            GameName = g2.Key,
                            TotalGames = g2.Count(),
                            TotalWins = (from wins in g2 where wins.Win == true select wins).Count(),
                            TotalScore = (int)g2.Sum(p => p.Score)
                        }).ToList();
            }
        }


        [HttpPost(Name = "CreatePlayerGame")]
        public int POST([FromBody] PlayerGameInput playerGameIn)
        {
            var playerGame = new Models.Playergame
            {
                Playerid = playerGameIn.Playerid,
                Gameid = playerGameIn.Gameid,
                Score = playerGameIn.Score,
                Win = playerGameIn.Win,
                Tournamentid = playerGameIn.Tournamentid
            };
            using (var db = _context)
            {
                db.Playergames.Add(playerGame);
                db.SaveChanges();
                return playerGame.Id;
            }
        }
    }
}