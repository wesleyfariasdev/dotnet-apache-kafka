using Confluent.Kafka;

namespace Kafka.Producer.Api.Services;

public class ProducerServices
{
    private readonly ILogger<ProducerServices> _logger;
    private readonly IConfiguration _configuration;
    private readonly ProducerConfig _producer;

    public ProducerServices(ILogger<ProducerServices> logger,
                            IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _producer = new ProducerConfig()
        {
            BootstrapServers = _configuration["KafkaConfig:BootstrapServer"]
        };
    }

    public async Task<string> SendMessage(string message)
    {

        var topic = _configuration["KafkaConfig:TopicName"];
        using var producer = new ProducerBuilder<Null, string>(_producer).Build();
        {
            try
            {
                var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
                var returnedMessage = $"Message '{message}' delivered to '{result.TopicPartitionOffset}'";
                _logger.LogInformation(returnedMessage);
                return returnedMessage;
            }
            catch (ProduceException<Null, string> ex)
            {
                var errorMessage = $"Delivery failed: {ex.Error.Reason}";
                _logger.LogError(errorMessage);
                return errorMessage;
            }
        }
    }
}
