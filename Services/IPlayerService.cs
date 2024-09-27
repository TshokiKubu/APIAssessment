using APIAssessment.Models;
using APIAssessment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAssessment.Services
{
    public interface IPlayerService
    {

        Task<PagedResult<PlayerCasinoWager>> GetPlayerWagers(Guid playerId, int page, int pageSize);
        Task<List<TopSpenderDto>> GetTopSpenders(int count);
        Task<PlayerCasinoWager> CreateWagerAsync(PlayerCasinoWager newWager);
    }
}
