using System;
using System.Collections.Generic;

namespace FamilyGameService.Models
{
    public partial class Game
    {
        public Game()
        {
            HouseRules = new HashSet<HouseRule>();
            Playergames = new HashSet<Playergame>();
        }

        public int Id { get; set; }
        public string? Gamename { get; set; }

        public virtual ICollection<HouseRule> HouseRules { get; set; }
        public virtual ICollection<Playergame> Playergames { get; set; }
    }
}
