using System;
using System.Collections.Generic;

namespace FamilyGameService.Models
{
    public partial class Bonu
    {
        public int Id { get; set; }
        public int? Tournamentid { get; set; }
        public int? Playerid { get; set; }
        public int? Points { get; set; }

        public virtual Player? Player { get; set; }
        public virtual Tournament? Tournament { get; set; }
    }
}
