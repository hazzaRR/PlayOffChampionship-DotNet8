using Microsoft.EntityFrameworkCore;

namespace PlayOffChampionship.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Leaderboard> Leaderboard { get; set; }
        public virtual DbSet<Match> Matches { get; set; }


    }
}
