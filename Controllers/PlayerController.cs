using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIAssessment.Models;
using APIAssessment.Services;
using APIAssessment.Models.Dtos;

namespace APIAssessment.Controllers
{
    [ApiController]
    [Route("api/player")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("{playerId}/casino")]
        public async Task<ActionResult<PagedResult<PlayerCasinoWager>>> GetWagers(Guid playerId, int page = 0, int pageSize = 10)
        {
            var result = await _playerService.GetPlayerWagers(playerId, page, pageSize);
            return Ok(result);
        }

        [HttpGet("topSpenders")]
        public async Task<ActionResult<List<TopSpenderDto>>> GetTopSpenders(int count = 10)
        {
            var topSpenders = await _playerService.GetTopSpenders(count);
            return Ok(topSpenders);
        }

        // POST method to create a new wager
        [HttpPost("wager")]
        public async Task<ActionResult<PlayerCasinoWager>> CreateWager([FromBody] PlayerCasinoWager newWager)
        {
            if (newWager == null)
            {
                return BadRequest("Wager data is null.");
            }

            // Call the service to create the wager
            var createdWager = await _playerService.CreateWagerAsync(newWager);

            // Return the created wager with a 201 Created status
            return CreatedAtAction(nameof(GetWagers), new { playerId = newWager.AccountId }, createdWager);
        }
    }
}
