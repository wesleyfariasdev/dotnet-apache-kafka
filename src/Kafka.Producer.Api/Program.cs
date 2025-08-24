using Kafka.Producer.Api.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ProducerServices>();

var app = builder.Build();

app.MapPost("/", async ([FromServices] ProducerServices services, [FromQuery] string message) =>
{
    return await services.SendMessage(message);
});

app.Run();
