using MarketApi.Databases.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarketApi.Config.ServiceConfig;

public static class ApiConfig
{

    #region ConfigureServices

    public static void AddSettingsConfig(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<AppSettings>(builder.Configuration);
    }
    
    public static void AddDatabaseContext(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(appSettings.DefaultConnection.DatabaseMarketApiConnectionString));

        using var servicesProvider = services.BuildServiceProvider();
        var db = servicesProvider.GetRequiredService<DatabaseContext>();
        db.Database.EnsureCreated();
        db.Database.Migrate();
    }

    #endregion
}