using PlayOffChampionship.Models;

namespace PlayOffChampionship.Dtos
{
    public class CreateMatchDto
    {
        public string Player1Id { get; set; }
        public string Player2Id { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public required string WinnerId { get; set; }
        public int LeagueId { get; set; }
        public DateTime MatchDate { get; set; }

    }
}
