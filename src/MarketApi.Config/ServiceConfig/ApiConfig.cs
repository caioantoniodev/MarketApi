using MarketApi.Databases.SqlServer;
using MarketApi.Outbound.Database.Products;
using MarketApi.Ports.Inbound.Products;
using MarketApi.Ports.Outbound.Products;
using MarketApi.Services.Products;
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
    
    public static void AddRegisterDependency(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddTransient<IProductServicePortInbound, ProductService>();
        services.AddTransient<IProductRepositoryPortOut, ProductRepository>();
        RegisterContext(services, appSettings);
    }

    private static void RegisterContext(IServiceCollection services, AppSettings appSettings)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(appSettings.DefaultConnection.DatabaseMarketApiConnectionString));
    }
    
    public static void UseMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        db.Database.EnsureCreated();
        db.Database.Migrate();
    }
    #endregion
}