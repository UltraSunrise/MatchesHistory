﻿namespace MatchesHistory.Data
{
    using MatchesHistory.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class MatchesHistoryDbContext : DbContext
    {
        public DbSet<Result> Results { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<PlayerPerformance> PlayersPerformance { get; set; }
        public DbSet<PlayedHeroes> PlayedHeroes { get; set; }
        public DbSet<Win> Wins { get; set; }
        public DbSet<Loss> Losses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Result>()
                .HasMany(r => r.Players)
                .WithOne(p => p.Result)
                .HasForeignKey(p => p.ResultId);

            builder
                .Entity<Player>()
                .HasMany(p => p.Abilities)
                .WithOne(a => a.Player)
                .HasForeignKey(a => a.PlayerId);

            builder
                .Entity<PlayerPerformance>()
                .HasMany(pp => pp.PlayedHeroes)
                .WithOne(ph => ph.PlayerPerformance)
                .HasForeignKey(ph => ph.PlayerPerformanceId);

            builder
                .Entity<Win>()
                .HasOne(w => w.PlayerPerformance)
                .WithMany(pp => pp.Wins)
                .HasForeignKey(w => w.PlayerPerformanceId);

            builder
                .Entity<Loss>()
                .HasOne(l => l.PlayerPerformance)
                .WithMany(pp => pp.Losses)
                .HasForeignKey(l => l.PlayerPerformanceId);
                
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=SomeDotes;Trusted_Connection=true");

            base.OnConfiguring(builder);
        }
    }
}
