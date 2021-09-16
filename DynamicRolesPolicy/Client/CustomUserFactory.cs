using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace DynamicRolesPolicy.Client;

public class CustomUserFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    public CustomUserFactory(IAccessTokenProviderAccessor accessor)
           : base(accessor)
    {
    }
    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        RemoteUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var user = await base.CreateUserAsync(account, options);
        var claimsIdentity = (ClaimsIdentity)user.Identity;
        if (account is not null)
        {
            MapArrayClaimsToMultipleSeparateClaims(account, claimsIdentity);
        }
        return user;
    }
    private void MapArrayClaimsToMultipleSeparateClaims(RemoteUserAccount account, ClaimsIdentity claimsIdentity)
    {
        foreach (var keyValuePair in account.AdditionalProperties)
        {
            var key = keyValuePair.Key;
            var value = keyValuePair.Value;
            if (value is not null &&
                value is JsonElement element && element.ValueKind == JsonValueKind.Array)
            {
                claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(keyValuePair.Key));
                var claims = element.EnumerateArray()
                    .Select(x => new Claim(keyValuePair.Key, x.ToString()));
                claimsIdentity.AddClaims(claims);
            }
        }
    }
}
