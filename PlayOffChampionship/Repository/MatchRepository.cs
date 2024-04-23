using Microsoft.EntityFrameworkCore;
using PlayOffChampionship.Dtos;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;
using PlayOffChampionship.Mappers;
using System.Numerics;

namespace PlayOffChampionship.Repository
{
    public class MatchRepository : IMatchRepository
    {

        private readonly AppDbContext _context;

        public MatchRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Match> Create(CreateMatchDto createMatchDto, Player player1, Player player2, League league, Player winner)
        {

            Match matchModel = createMatchDto.ToMatchFromCreateMatchDto(player1, player2, league, winner);
            

            //add match to the database
            var match = _context.Matches.Add(matchModel);


            //get the winnersLeaderboard and update their rankings
            var winnerLeaderboard = await _context.Leaderboard.FirstOrDefaultAsync(leaderboard => leaderboard.Player == winner && leaderboard.League == league);
            if (winnerLeaderboard != null)
            {
                winnerLeaderboard.TotalMatches = winnerLeaderboard.TotalMatches + 1;
                winnerLeaderboard.TotalWins = winnerLeaderboard.TotalWins + 1;
                winnerLeaderboard.Points = winnerLeaderboard.Points + 3;
            }
            else
            {
                Leaderboard leaderboard = new()
                {
                    League = league,
                    Player = winner,
                    TotalMatches = 1,
                    TotalWins = 1,
                    Points = 3
                };


                _context.Leaderboard.Add(leaderboard);
            }
            

            //find the losers leaderboard by checking for the playersId that is not equal to the winner
            Leaderboard? loserLeaderboard;
            Player? loser;

            if (player1.Id != winner.Id)
            {
                loser = player1;
                loserLeaderboard = await _context.Leaderboard.FirstOrDefaultAsync(leaderboard => leaderboard.Player == player1 && leaderboard.League == league);
            }
            else
            {
                loser = player2;
                loserLeaderboard = await _context.Leaderboard.FirstOrDefaultAsync(leaderboard => leaderboard.Player == player2 && leaderboard.League == league);
            }

            //update their leaderboard stats
            if (loserLeaderboard != null)
            {
                loserLeaderboard.TotalMatches = loserLeaderboard.TotalMatches + 1;
            }
            else
            {
                Leaderboard leaderboard = new()
                {
                    League = league,
                    Player = loser,
                    TotalMatches = 1,
                    TotalWins = 0,
                    Points = 0
                };


                _context.Leaderboard.Add(leaderboard);
            }
            

            await _context.SaveChangesAsync();

            return matchModel;

        }

        public async Task<Match?> Delete(int id)
        {
            Match? match = await _context.Matches.FirstOrDefaultAsync(match => match.Id == id);

            if (match == null)
            {
                return null;
            }

            Leaderboard? winnerLeaderboard = await _context.Leaderboard.FirstOrDefaultAsync(leaderboard => leaderboard.PlayerId == match.WinnerId);

            if (winnerLeaderboard == null)
            {
                return null;
            }

            winnerLeaderboard.TotalMatches = winnerLeaderboard.TotalMatches - 1;
            winnerLeaderboard.Points = winnerLeaderboard.Points - 3;
            winnerLeaderboard.TotalWins = winnerLeaderboard.TotalWins - 1;

            Leaderboard? loserLeaderboard;

            if (match.Winner != match.Player1)
            {
                loserLeaderboard = await _context.Leaderboard.FirstOrDefaultAsync(leaderboard => leaderboard.PlayerId == match.Player1Id);
            }
            else
            {
                loserLeaderboard = await _context.Leaderboard.FirstOrDefaultAsync(leaderboard => leaderboard.PlayerId == match.Player2Id);
            }

            loserLeaderboard.TotalMatches = loserLeaderboard.TotalMatches - 1;

            if (loserLeaderboard == null)
            {
                return null;
            }


            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();

            return match;
        }

        public async Task<Match?> GetById(int id)
        {
            var match = await _context.Matches
                .Include(match => match.Player1)
                .Include(match => match.Player2)
                .Include(match => match.League)
                .Include(match => match.Winner)
                .FirstOrDefaultAsync(match => match.Id == id);

            if (match == null)
            {
                return null;
            }

            return match;
        }

        public async Task<List<Match>> GetByLeagueId(int leagueId)
        {
                 var matches = await _context.Matches
                .Include(match => match.Player1)
                .Include(match => match.Player2)
                .Include(match => match.League)
                .Include(match => match.Winner)
                .Where(match => match.LeagueId == leagueId)
                .ToListAsync();


                return matches;
            }

        public async Task<List<Match>> GetByPlayerId(int playerId)
        {
            var matches = await _context.Matches
            .Include(match => match.Player1)
            .Include(match => match.Player2)
            .Include(match => match.League)
            .Include(match => match.Winner)
            .Where(match => match.Player1Id == playerId || match.Player2Id == playerId)
            .ToListAsync();


            return matches;
        }

        public async Task<List<Match>> GetByWinnerId(int winnerId)
        {
            var matches = await _context.Matches
            .Include(match => match.Player1)
            .Include(match => match.Player2)
            .Include(match => match.League)
            .Include(match => match.Winner)
            .Where(match => match.WinnerId == winnerId)
            .ToListAsync();


            return matches;
        }

        public async Task<Match?> Update(int id, Match match)
        {
            var matchObject = await _context.Matches.FirstOrDefaultAsync(match => match.Id == id);


            if (matchObject == null)
            {
                return null;
            }

            matchObject.Player1 = match.Player1;
            matchObject.Player2 = match.Player2;
            matchObject.Winner = match.Winner;
            matchObject.WinnerId = match.WinnerId;
            matchObject.Player2Id = match.Player2Id;
            matchObject.Player1Id = match.Player1Id;
            matchObject.League = match.League;
            matchObject.LeagueId = match.LeagueId;
            matchObject.Player1Score = match.Player1Score;
            matchObject.Player2Score = match.Player2Score;

            await _context.SaveChangesAsync();

            return matchObject;

        }
    }
}
