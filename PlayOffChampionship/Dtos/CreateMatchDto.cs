using PlayOffChampionship.Models;

namespace PlayOffChampionship.Dtos
{
    public class CreateMatchDto
    {
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int WinnerId { get; set; }
        public int LeagueId { get; set; }
        public DateTime MatchDate { get; set; }

    }
}
