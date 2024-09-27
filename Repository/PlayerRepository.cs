using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIAssessment.Data;
using APIAssessment.Models;
using APIAssessment.Models.Dtos;

namespace APIAssessment.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PlayerCasinoWager>> GetWagersByPlayer(Guid playerId, int page, int pageSize)
        {
            var wagers = await _context.PlayerCasinoWagers
                .Where(w => w.AccountId == playerId)
                .OrderByDescending(w => w.CreatedDateTime)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return wagers;
        }

        public async Task<List<TopSpenderDto>> GetTopSpenders(int count)
        {
            var topSpenders = await _context.PlayerCasinoWagers
                .GroupBy(w => w.AccountId) // Group by AccountId only
                .Select(g => new
                {
                    AccountId = g.Key,
                    TotalAmount = g.Sum(w => w.Amount) // Calculate total wager amount per account
                })
                .OrderByDescending(x => x.TotalAmount) // Order by total wager amount
                .Take(count) // Limit the result to the top spenders
                .Join(_context.PlayerAccounts, // Join with PlayerAccounts to get the Username
                      g => g.AccountId, // Join on AccountId
                      p => p.AccountId,
                      (g, p) => new TopSpenderDto
                      {
                          AccountId = g.AccountId,
                          Username = p.Username, // Get the Username from PlayerAccount
                          TotalAmountSpend = g.TotalAmount // Use the calculated total amount
                      })
                .ToListAsync();

            return topSpenders;
        }


        public async Task<int> GetTotalWagersCount(Guid playerId) 
        {
            return await _context.PlayerCasinoWagers
                .CountAsync(w => w.AccountId == playerId); // Count the total wagers for the player
        }
        
        public async Task<PlayerCasinoWager> AddWagerAsync(PlayerCasinoWager wager)
        {
            await _context.PlayerCasinoWagers.AddAsync(wager);
            await _context.SaveChangesAsync();

            return wager;
        }
    }
}
