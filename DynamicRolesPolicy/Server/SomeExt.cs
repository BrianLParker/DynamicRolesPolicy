using DynamicRolesPolicy.Shared.Models.Configurations;

namespace DynamicRolesPolicy.Server;

public static class SomeExt
{
    public static void asdasd(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;

        adasd(services, configuration);

    }

    public static void adasd(this IServiceCollection services, IConfiguration configuration)
    {
        var localConfiguration = configuration.Get<LocalConfiguration>();
        services.AddSingleton(localConfiguration);
    }
}
