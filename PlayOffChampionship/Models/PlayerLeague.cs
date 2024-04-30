using System.ComponentModel.DataAnnotations.Schema;

namespace PlayOffChampionship.Models
{


    [Table("player_league")]
    public class PlayerLeague
    {

        public required string PlayerId { get; set; }
        public required ApplicationUser Player { get; set; }

        public int LeagueId { get; set; }
        public required League League { get; set; }

    }
}
