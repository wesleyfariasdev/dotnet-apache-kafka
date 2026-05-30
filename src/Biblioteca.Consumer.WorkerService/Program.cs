using Biblioteca.Consumer.WorkerService;
using Confluent.Kafka;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IConsumer<Ignore, string>>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var consumerConfig = new ConsumerConfig
    {
        BootstrapServers = configuration["KafkaConfig:BootstrapServer"],
        GroupId = configuration["KafkaConfig:GroupId"],
        AutoOffsetReset = AutoOffsetReset.Earliest
    };
    return new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
});

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
