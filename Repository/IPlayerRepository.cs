using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIAssessment.Models;
using APIAssessment.Models.Dtos;

namespace APIAssessment.Repository
{
    public interface IPlayerRepository
    {
        Task<List<PlayerCasinoWager>> GetWagersByPlayer(Guid playerId, int page, int pageSize);
        Task<List<TopSpenderDto>> GetTopSpenders(int count);
        Task<int> GetTotalWagersCount(Guid playerId);
        Task<PlayerCasinoWager> AddWagerAsync(PlayerCasinoWager wager);
    }
       
}
