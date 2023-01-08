namespace MarketApi.Config.ServiceConfig;

public class AppSettings
{
    public DefaultConnection DefaultConnection { get; set; } = null!;
}

public class DefaultConnection
{
    public string DatabaseMarketApiConnectionString { get; set; } = null!;
    public string CacheConnectionString { get; set; } = null!;
}