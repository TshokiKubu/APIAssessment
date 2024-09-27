using APIAssessment.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using System.Globalization;

namespace APIAssessment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PlayerAccount> PlayerAccounts { get; set; }
        public DbSet<PlayerCasinoWager> PlayerCasinoWagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
                // Configure PlayerCasinoWager
            modelBuilder.Entity<PlayerCasinoWager>(entity =>
            {

                entity.HasKey(cw => cw.WagerId);
                entity.Property(cw => cw.Theme)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(cw => cw.Provider)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(cw => cw.Amount)
             .HasColumnType("decimal(18, 4)"); // Set precision for Amount column


                // Define the relationship with PlayerAccount using the foreign key AccountId
                entity.HasOne(cw => cw.PlayerAccount)
                      .WithMany(pa => pa.PlayerCasinoWagers)
                      .HasForeignKey(cw => cw.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Store the enum 'Status' as an integer
                entity.Property(cw => cw.Status)
                      .HasConversion<int>();
            });

            // Configure PlayerAccount
            modelBuilder.Entity<PlayerAccount>(entity =>
            {
                entity.HasKey(pa => pa.AccountId);
                entity.Property(pa => pa.Username)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            // Seed initial data for PlayerAccount and PlayerCasinoWager
            SeedInitialData(modelBuilder);
        }

        // Removed 'Username' from PlayerCasinoWager as it is redundant
        // 'PlayerAccount' already handles username through the foreign key relationship.
        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            // Generate unique GUIDs for player accounts
            var player1Id = Guid.NewGuid();
            var player2Id = Guid.NewGuid();
            var player3Id = Guid.NewGuid();

            // Seed PlayerAccount data
            modelBuilder.Entity<PlayerAccount>().HasData(
                new PlayerAccount
                {
                    AccountId = player1Id,
                    Username = "Max.Booth67"
                },
                new PlayerAccount
                {
                    AccountId = player2Id,
                    Username = "Sentle.Morake88"
                },
                new PlayerAccount
                {
                    AccountId = player3Id,
                    Username = "Bova.Senoinoi11"
                }
            );

            // Seed PlayerCasinoWager data and ensure it is correctly linked to PlayerAccount via AccountId
            modelBuilder.Entity<PlayerCasinoWager>().HasData(
                new PlayerCasinoWager
                {
                    WagerId = Guid.NewGuid(),
                    Theme = "Adventure",
                    Provider = "Ergonomic Soft Fish",
                    GameName = "Ergonomic Granite Cheese",
                    TransactionId = Guid.NewGuid(),
                    BrandId = Guid.NewGuid(),
                    AccountId = player1Id, // Link to player1
                    Amount = 38273.97M,
                    CreatedDateTime = DateTime.UtcNow,
                    NumberOfBets = 3,
                    CountryCode = "ZAR",
                    SessionData = "Sample session data",
                    Duration = 1827254
                },
                new PlayerCasinoWager
                {
                    WagerId = Guid.NewGuid(),
                    Theme = "Mystery",
                    Provider = "Ultimate Games Ltd",
                    GameName = "Mystery of the Lost Tomb",
                    TransactionId = Guid.NewGuid(),
                    BrandId = Guid.NewGuid(),
                    AccountId = player2Id, // Link to player2
                    Amount = 52450.12M,
                    CreatedDateTime = DateTime.UtcNow,
                    NumberOfBets = 5,
                    CountryCode = "ZAR",
                    SessionData = "Sample session data for mystery game",
                    Duration = 2657842
                },
                new PlayerCasinoWager
                {
                    WagerId = Guid.NewGuid(),
                    Theme = "Space",
                    Provider = "Next Gen Gaming",
                    GameName = "Starscape Galaxy Quest",
                    TransactionId = Guid.NewGuid(),
                    BrandId = Guid.NewGuid(),
                    AccountId = player3Id, // Link to player3
                    Amount = 19834.75M,
                    CreatedDateTime = DateTime.UtcNow,
                    NumberOfBets = 2,
                    CountryCode = "ZAR",
                    SessionData = "Sample session data for space game",
                    Duration = 1458721
                }
            );
        }
    }
}
