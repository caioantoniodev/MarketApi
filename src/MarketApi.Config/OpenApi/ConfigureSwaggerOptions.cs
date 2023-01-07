using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MarketApi.Config.OpenApi;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }
    
    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
        
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        
        options.EnableAnnotations();
    }

    private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Version = "v1",
            Title = "MarketApi",
            Description = "Back-end of one of my projects simulating a e-commerce, made to learn DotNet.",
            Contact = new OpenApiContact
            {
                Name = "e-mail",
                Email = "mailto:caio.antonio.c@outlook.com"
            },
        };

        if (description.IsDeprecated)
        {
            info.Description +=
                "This API version has been deprecated, please use a newer one available.";
        }

        return info;
    }
}