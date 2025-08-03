namespace Billings.Application.Common;

/// <summary>
/// Список топиков Kafka.
/// </summary>
public static class KafkaTopics
{
    /// <summary>
    /// Represents the Kafka topic name for generated invoices.
    /// </summary>
    public const string InvoiceCreated = "invoice-created";

    /// <summary>
    /// Represents the Kafka topic name for created usage events.
    /// </summary>
    public const string UsageCreated = "usage-created";
}