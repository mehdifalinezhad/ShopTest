using EndPoint.Admin.Authorization.ClaimBasedAuthorization.Utilities;
using EndPoint.Admin.Authorization.ClaimBasedAuthorization.Utilities.MvcNamesUtilities;
using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Admin.Authorization.ClaimBasedAuthorization
{
    public static class DependencyInjection
    {
        public static void AddClaimBasedAuthorization(this IServiceCollection service)
        {
            service.AddHttpContextAccessor();
            service.AddSingleton<IClaimBasedAuthorizationUtilities, ClaimBasedAuthorizationUtilities>();
            service.AddSingleton<IMvcUtilities, MvcUtilities>();
            service.AddScoped<IAuthorizationHandler, ClaimBasedAuthorizationHandler>();
            service.AddAuthorization(option =>
            {
                option.AddPolicy("ClaimBasedAuthorization", policy =>
                    policy.Requirements.Add(new ClaimBasedAuthorizationRequirement()));
            });
        }
    }
}
