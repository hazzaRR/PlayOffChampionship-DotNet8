﻿using PlayOffChampionship.Models;

namespace PlayOffChampionship.Dtos.League
{
    public class LeagueDto
    {

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Player> Players { get; set; }
    }
}
