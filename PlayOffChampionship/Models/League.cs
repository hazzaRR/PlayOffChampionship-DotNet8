using System.ComponentModel.DataAnnotations.Schema;

namespace PlayOffChampionship.Models
{


    [Table("league")]
    public class League
    {

        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();


    }
}
