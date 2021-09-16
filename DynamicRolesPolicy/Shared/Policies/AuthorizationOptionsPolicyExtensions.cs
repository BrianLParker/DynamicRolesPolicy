

using DynamicRolesPolicy.Shared.Models.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicRolesPolicy.Shared.Policies;

public static class AuthorizationOptionsPolicyExtensions
{
    public static void AddPolicies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthorizationHandler, HasRolesFromConfigHandler>();
        services.AddAuthorizationCore(options => options.ConfigurePolicies(configuration));
    }

    public static AuthorizationOptions ConfigurePolicies(this AuthorizationOptions options, IConfiguration configuration)
    {
        var localConfiguration = configuration.Get<LocalConfiguration>();
        options.AddPolicy("HasARequiredRole", policy => policy.Requirements.Add(new HasRolesFromConfigRequirement(localConfiguration.AllowedGroups)));
        return options;
    }

}
