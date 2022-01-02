using System;
using System.Collections.Generic;

namespace FamilyGameService.Models
{
    public partial class HouseRule
    {
        public int Id { get; set; }
        public string? Rule { get; set; }
        public int? Gameid { get; set; }

        public virtual Game? Game { get; set; }
    }
}
