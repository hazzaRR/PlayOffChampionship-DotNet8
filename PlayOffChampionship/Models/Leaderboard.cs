namespace PlayOffChampionship.Models
{
    public class Leaderboard
    {

        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int LeagueId { get; set; }
        public int TotalWins { get; set; }
        public int TotalMatches { get; set; }

        public required Player Player { get; set; }
        public required League League { get; set; }
    }
}
