using System;
using System.Collections.Generic;

namespace FamilyGameService.Models
{
    public partial class Playergame
    {
        public int Id { get; set; }
        public int? Playerid { get; set; }
        public int? Gameid { get; set; }
        public int? Score { get; set; }
        public bool? Win { get; set; }
        public int? Tournamentid { get; set; }

        public virtual Game? Game { get; set; }
        public virtual Player? Player { get; set; }
        public virtual Tournament? Tournament { get; set; }
    }
}
