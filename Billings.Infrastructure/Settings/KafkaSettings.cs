namespace Billings.Infrastructure.Settings;

public class KafkaSettings
{
    public string BootstrapServers { get; set; } = default!;
    public string Acks { get; set; } = "all";
    public int Retries { get; set; } = 3;
    public bool EnableIdempotence { get; set; } = true;
    public string CompressionType { get; set; } = "none";
}
