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
        public virtual DbSet<PlayerLeague> PlayerLeagues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerLeague>()
                .HasKey(pl => new { pl.PlayerId, pl.LeagueId });

            modelBuilder.Entity<Leaderboard>()
                .HasIndex(l => new { l.PlayerId, l.LeagueId }).IsUnique();
        }

    }
}
