using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FamilyGameService.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bonu> Bonus { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<HouseRule> HouseRules { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Playergame> Playergames { get; set; } = null!;
        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=192.168.86.28:5432;Database=postgres;UserName=postgres;Password=m@cAr0n1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

            modelBuilder.Entity<Bonu>(entity =>
            {
                entity.ToTable("bonus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Playerid).HasColumnName("playerid");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Tournamentid).HasColumnName("tournamentid");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Bonus)
                    .HasForeignKey(d => d.Playerid)
                    .HasConstraintName("fk_bonus_player");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Bonus)
                    .HasForeignKey(d => d.Tournamentid)
                    .HasConstraintName("fk_bonus_tournament");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gamename)
                    .HasMaxLength(150)
                    .HasColumnName("gamename");
            });

            modelBuilder.Entity<HouseRule>(entity =>
            {
                entity.ToTable("house_rules");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gameid).HasColumnName("gameid");

                entity.Property(e => e.Rule)
                    .HasColumnType("character varying")
                    .HasColumnName("rule");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.HouseRules)
                    .HasForeignKey(d => d.Gameid)
                    .HasConstraintName("fk_game");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Playername)
                    .HasMaxLength(150)
                    .HasColumnName("playername");
            });

            modelBuilder.Entity<Playergame>(entity =>
            {
                entity.ToTable("playergames");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gameid).HasColumnName("gameid");

                entity.Property(e => e.Playerid).HasColumnName("playerid");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Tournamentid).HasColumnName("tournamentid");

                entity.Property(e => e.Win).HasColumnName("win");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Playergames)
                    .HasForeignKey(d => d.Gameid)
                    .HasConstraintName("fk_pg_game");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Playergames)
                    .HasForeignKey(d => d.Playerid)
                    .HasConstraintName("fk_pg_player");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Playergames)
                    .HasForeignKey(d => d.Tournamentid)
                    .HasConstraintName("fk_pg_tournament");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("tournaments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tournamentname)
                    .HasMaxLength(150)
                    .HasColumnName("tournamentname");

                entity.Property(e => e.Winner).HasColumnName("winner");

                entity.HasOne(d => d.WinnerNavigation)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.Winner)
                    .HasConstraintName("fk_player");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
