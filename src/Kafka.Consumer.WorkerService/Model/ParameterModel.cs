namespace Kafka.Consumer.WorkerService.Model;

internal sealed class ParameterModel(IConfiguration _configuration)
{
    public string BootstrapServers { get; set; } = _configuration["KafkaConfig:BootstrapServer"]!;
    public string TopicName { get; set; } = _configuration["KafkaConfig:TopicName"]!;
    public string GroupId { get; set; } = _configuration["KafkaConfig:GroupId"]!;
}
