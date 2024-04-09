using PlayOffChampionship.Models;

namespace PlayOffChampionship.Dtos
{
    public class LeaderboardDto
    {

        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int LeagueId { get; set; }
        public int TotalWins { get; set; } = 0;
        public int TotalMatches { get; set; } = 0;
        public int Points { get; set; } = 0;
        public required PlayerDto PlayerDto { get; set; }
        public required LeagueDto LeagueDto { get; set; }
    }
}
