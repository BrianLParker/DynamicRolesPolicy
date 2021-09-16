using Microsoft.AspNetCore.Authorization;

namespace DynamicRolesPolicy.Shared.Policies;

public class HasRolesFromConfigRequirement : IAuthorizationRequirement
{
    internal string[] allowedGroups;
    public HasRolesFromConfigRequirement(string[]? allowedGroups) => this.allowedGroups = allowedGroups;
}
public class HasRolesFromConfigHandler : AuthorizationHandler<HasRolesFromConfigRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        HasRolesFromConfigRequirement requirement)
    {
        var rolesRequired = requirement.allowedGroups;
        if (rolesRequired is null)
        {
            context.Fail();
        }
        else
        {
            var hasRequiredRole = rolesRequired.Where(role => context.User.IsInRole(role)).Any();
            if (hasRequiredRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
        return Task.CompletedTask;
    }
}