using System;
using System.Collections.Generic;

namespace FamilyGameService.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            Bonus = new HashSet<Bonu>();
        }

        public int Id { get; set; }
        public string? Tournamentname { get; set; }
        public int? Winner { get; set; }

        public virtual Player? WinnerNavigation { get; set; }
        public virtual ICollection<Bonu> Bonus { get; set; }
    }
}
