using System;
using System.Collections.Generic;

namespace FamilyGameService.Models
{
    public partial class Player
    {
        public Player()
        {
            Bonus = new HashSet<Bonu>();
            Playergames = new HashSet<Playergame>();
            Tournaments = new HashSet<Tournament>();
        }

        public int Id { get; set; }
        public string? Playername { get; set; }

        public virtual ICollection<Bonu> Bonus { get; set; }
        public virtual ICollection<Playergame> Playergames { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
