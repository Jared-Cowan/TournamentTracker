using System;
using System.Collections.Generic;

namespace TournamentTracker.Data
{
    public partial class TournamentsContext : DbContext
    {
        public virtual DbSet<Matchup> Matchups { get; set; }
        public virtual DbSet<MatchupEntry> MatchupEntries { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Prize> Prizes { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<TournamentEntry> TournamentEntries { get; set; }
        public virtual DbSet<TournamentPrize> TournamentPrizes { get; set; }

        public TournamentsContext(DbContextOptions<TournamentsContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-CL000050;Initial Catalog=Tournaments;Integrated Security=True;Trust Server Certificate=True;Command Timeout=300");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matchup>(entity =>
            {
                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Matchups)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matchups_Tournaments");

                entity.HasOne(d => d.Winner)
                    .WithMany(p => p.Matchups)
                    .HasForeignKey(d => d.WinnerId)
                    .HasConstraintName("FK_Matchups_Teams");
            });

            modelBuilder.Entity<MatchupEntry>(entity =>
            {
                entity.HasOne(d => d.Matchup)
                    .WithMany(p => p.MatchupEntries)
                    .HasForeignKey(d => d.MatchupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchupEntries_Matchups");

                entity.HasOne(d => d.TeamCompeting)
                    .WithMany(p => p.MatchupEntries)
                    .HasForeignKey(d => d.TeamCompetingId)
                    .HasConstraintName("FK_MatchupEntries_Teams");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.CellphoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamMembers_People");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamMembers_Teams");
            });

            modelBuilder.Entity<TournamentEntry>(entity =>
            {
                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TournamentEntries)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentEntries_Teams");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentEntries)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentEntries_Tournaments");
            });

            modelBuilder.Entity<TournamentPrize>(entity =>
            {
                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentPrizes)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentPrizes_Prizes");

                entity.HasOne(d => d.TournamentNavigation)
                    .WithMany(p => p.TournamentPrizes)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentPrizes_Tournaments");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
