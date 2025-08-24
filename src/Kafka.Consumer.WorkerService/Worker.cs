using Confluent.Kafka;
using Kafka.Consumer.WorkerService.Model;

namespace Kafka.Consumer.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly ParameterModel _parameterModel;

        public Worker(ILogger<Worker> logger,
                      IConfiguration configuration,
                      IConsumer<Ignore, string> consumer)
        {
            _logger = logger;
            _consumer = consumer;
            _configuration = configuration;
            _parameterModel = new ParameterModel(_configuration);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(_parameterModel.TopicName);
            _logger.LogInformation("BootstrapServers: {BootstrapServers}", _parameterModel.BootstrapServers);
            _logger.LogInformation("TopicName: {TopicName}", _parameterModel.TopicName);

            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    var result = _consumer.Consume(stoppingToken);
                    _logger.LogInformation("Message: {Message}", result.Message.Value);
                }
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _consumer.Close();
            _consumer.Dispose();
            _logger.LogInformation("Worker disposed at: {time}", DateTimeOffset.Now);

            return base.StopAsync(cancellationToken);
        }
    }
}
