using System.ComponentModel.DataAnnotations.Schema;

namespace PlayOffChampionship.Models
{

    [Table("player")]
    public class Player
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<League> Leagues { get; set; } = new List<League>();
    }
}
