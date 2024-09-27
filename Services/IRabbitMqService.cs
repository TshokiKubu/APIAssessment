// Services/IRabbitMqService.cs
using APIAssessment.Models;
using Microsoft.AspNetCore.Connections;
using System.Text.Json;
using System.Text;

public interface IRabbitMqService
{
    Task PublishWagerToQueue(PlayerCasinoWager wager);
}
