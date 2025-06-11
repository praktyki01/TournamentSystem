using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TournamentSystem.Models;

namespace TournamentSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany(t => t.MatchTeam1)
                .HasForeignKey(m => m.Team1Id)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany(t => t.MatchTeam2)
                .HasForeignKey(m => m.Team2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<TournamentSystem.Models.Game> Game { get; set; } = default!;
        public DbSet<TournamentSystem.Models.Match> Match { get; set; } = default!;
        public DbSet<TournamentSystem.Models.MatchDetail> MatchDetail { get; set; } = default!;
        public DbSet<TournamentSystem.Models.Player> Player { get; set; } = default!;
        public DbSet<TournamentSystem.Models.Team> Team { get; set; } = default!;
        public DbSet<TournamentSystem.Models.TeamTournament> TeamTournament { get; set; } = default!;
        public DbSet<TournamentSystem.Models.Tournament> Tournament { get; set; } = default!;
    }
}
