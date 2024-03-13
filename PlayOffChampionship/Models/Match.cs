using System.ComponentModel.DataAnnotations.Schema;

namespace PlayOffChampionship.Models
{

    [Table("match")]
    public class Match
    {
        public int Id { get; set; }

        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int WinnerId { get; set; }
        public int LeagueId { get; set; }
        public DateTime MatchDate { get; set; }
        public required Player Player1 { get; set; }
        public required Player Player2 { get; set; }
        public required Player Winner { get; set; }
        public required League League { get; set; }


    }
}
