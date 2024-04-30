using System.ComponentModel.DataAnnotations.Schema;

namespace PlayOffChampionship.Models
{

    [Table("match")]
    public class Match
    {
        public int Id { get; set; }

        public string Player1Id { get; set; }
        public  string Player2Id { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public string WinnerId { get; set; }
        public int LeagueId { get; set; }
        public DateTime MatchDate { get; set; }
        public required ApplicationUser Player1 { get; set; }
        public required ApplicationUser Player2 { get; set; }
        public required ApplicationUser Winner { get; set; }
        public required League League { get; set; }


    }
}
