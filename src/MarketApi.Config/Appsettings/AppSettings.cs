namespace MarketApi.Config.Appsettings;

public class AppSettings
{
    public DefaultConnection? DefaultConnection { get; set; }
}

public class DefaultConnection
{
    public string? DatabaseMarketApiConnectionString { get; set; }
    public string? CacheConnectionString { get; set; }
}