﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PlayOffChampionship.Models
{


    [Table("leaderboard")]
    public class Leaderboard
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int LeagueId { get; set; }
        public int TotalWins { get; set; } = 0;
        public int TotalMatches { get; set; } = 0;
        public int Points { get; set; } = 0; 
        public required Player Player { get; set; }
        public required League League { get; set; }
    }
}
