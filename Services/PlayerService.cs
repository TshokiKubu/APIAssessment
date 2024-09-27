using APIAssessment.Models.Dtos;
using APIAssessment.Models.Enums;
using APIAssessment.Models;
using APIAssessment.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAssessment.Services
{
    public class PlayerService : IPlayerService // Ensure this line is correct
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<PagedResult<PlayerCasinoWager>> GetPlayerWagers(Guid playerId, int page, int pageSize)
        {
            var total = await _playerRepository.GetTotalWagersCount(playerId);
            var wagers = await _playerRepository.GetWagersByPlayer(playerId, page, pageSize);

            return new PagedResult<PlayerCasinoWager>
            {
                Data = wagers,
                Page = page,
                PageSize = pageSize,
                Total = total,
                TotalPages = (int)Math.Ceiling((double)total / pageSize)
            };
        }

        public async Task<List<TopSpenderDto>> GetTopSpenders(int count)
        {
            var topSpenders = await _playerRepository.GetTopSpenders(count);
            return topSpenders;
        }

        public async Task<PlayerCasinoWager> CreateWagerAsync(PlayerCasinoWager newWager)
        {
            // Set the initial status to Pending
            newWager.Status = WagerStatus.Pending;
            newWager.CreatedDateTime = DateTime.UtcNow; // Set the creation date

            // Call the repository to save the new wager
            return await _playerRepository.AddWagerAsync(newWager);
        }
    }
}
