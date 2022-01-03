namespace FamilyGameService.DTOs
{
    public class PlayerGameInput
    {
        public int Playerid { get; set; }
        public int Gameid { get; set; }
        public int? Score { get; set; }
        public bool Win { get; set; }
        public int? Tournamentid { get; set; }
    }
}
