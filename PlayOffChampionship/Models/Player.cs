using System.ComponentModel.DataAnnotations.Schema;

namespace PlayOffChampionship.Models
{

    [Table("player")]
    public class Player
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? LeagueId { get; set; }
        public League? League { get; set; }
    }
}
