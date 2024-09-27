using APIAssessment.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class RabbitMqService : IRabbitMqService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<RabbitMqService> _logger;  
    private IConnection _connection;
    private IModel _channel;

    public RabbitMqService(IConfiguration configuration, ILogger<RabbitMqService> logger)
    {
        _configuration = configuration;
        _logger = logger;
        InitializeRabbitMq();
    }

    private void InitializeRabbitMq()
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration["RabbitMq:HostName"],
                UserName = _configuration["RabbitMq:UserName"],
                Password = _configuration["RabbitMq:Password"],
                Port = 5672 // Default AMQP port
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declare a queue for bet way wagers
            _channel.QueueDeclare(
                queue: "bet_way_queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _logger.LogInformation("RabbitMQ connection initialized successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to initialize RabbitMQ connection.");
            throw;
        }
    }

    public async Task PublishWagerToQueue(PlayerCasinoWager wager)
    {
        try
        {
            // Serialize the wager object to JSON asynchronously
            var json = JsonSerializer.Serialize(wager);
            var body = Encoding.UTF8.GetBytes(json);

            _logger.LogInformation("Publishing wager with WagerId: {WagerId} to the queue.", wager.WagerId);

            // Publish the message to the RabbitMQ queue asynchronously using Task.Run
            await Task.Run(() =>
            {
                _channel.BasicPublish(
                    exchange: "",
                    routingKey: "casino_wager_queue",
                    basicProperties: null,
                    body: body);
            });            
            _logger.LogInformation("Wager with WagerId: {WagerId} successfully published to the queue.", wager.WagerId);
        }
        catch (Exception ex)
        {            
            _logger.LogError(ex, "Error publishing wager with WagerId: {WagerId} to RabbitMQ.", wager.WagerId);
            throw new Exception("Error publishing wager to RabbitMQ", ex);
        }
    }

    // Method to close the connection
    public void CloseConnection()
    {
        try
        {
            if (_channel != null && _channel.IsOpen)
            {
                _channel.Close();
                _logger.LogInformation("RabbitMQ channel closed.");
            }

            if (_connection != null && _connection.IsOpen)
            {
                _connection.Close();
                _logger.LogInformation("RabbitMQ connection closed.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error closing RabbitMQ connection.");
        }
    }
}
