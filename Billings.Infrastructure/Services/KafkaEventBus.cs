namespace Billings.Infrastructure.Services;

using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Application.Abstractions;
using Domain.Abstractions;
using Settings;

public class KafkaEventBus : IEventBus
{
    private readonly IProducer<string, string> _producer;
    private readonly ILogger<KafkaEventBus> _logger;

    /// <summary>
    /// Создает экземпляр KafkaEventBus с конфигурацией продюсера.
    /// </summary>
    public KafkaEventBus(IOptions<KafkaSettings> kafkaOptions, ILogger<KafkaEventBus> logger)
    {
        var options = kafkaOptions.Value;
        var config = new ProducerConfig
        {
            BootstrapServers = options.BootstrapServers,
            Acks = Enum.Parse<Acks>(kafkaOptions.Value.Acks),
            EnableIdempotence = options.EnableIdempotence,
            CompressionType = Enum.Parse<CompressionType>(options.CompressionType, true)
        };

        _producer = new ProducerBuilder<string, string>(config).Build();
        _logger = logger;
    }

    /// <summary>
    /// Публикует событие в Kafka.
    /// </summary>
    public async Task PublishAsync<T>(string topic, T @event) where T : IDomainEvent
    {
        var json = JsonSerializer.Serialize(@event);
        var key = Guid.NewGuid().ToString();

        try
        {
            var result = await _producer.ProduceAsync(topic, new Message<string, string>
            {
                Key = key,
                Value = json
            });

            _logger.LogInformation("Событие опубликовано: topic={Topic}, partition={Partition}, offset={Offset}", topic, result.Partition, result.Offset);
        }
        catch (ProduceException<string, string> ex)
        {
            _logger.LogError(ex, "Ошибка при отправке события в Kafka (topic: {Topic})", topic);
            throw;
        }
    }
}
