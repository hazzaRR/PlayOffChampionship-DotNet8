﻿using PlayOffChampionship.Models;

namespace PlayOffChampionship.Interfaces
{
    public interface ILeaderboardRepository
    {

       Task<List<Leaderboard>> GetByLeagueId(int leagueId);


        Task<Leaderboard?> GetByLeagueIdAndPlayerId(int leagueId, int  playerId);

        Task<Leaderboard> Create(Leaderboard leaderboard);

        Task<Leaderboard> Update(Leaderboard leaderboard);
    }
}
