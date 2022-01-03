namespace FamilyGameService.DTOs
{
    public class GetPlayerStatsResponse
    {
        public int TotalWins { get; set; }
        public int TotalGames { get; set; }
        public String? GameName { get; set; }
        public int TotalScore { get; set; }
    }
}
