using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Admin.Authorization.ClaimBasedAuthorization.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ClaimBasedAuthorizationAttribute : AuthorizeAttribute
    {
        public ClaimBasedAuthorizationAttribute(string claimToAuthorize) : base("ClaimBasedAuthorization")
        {
            ClaimToAuthorize = claimToAuthorize;
        }
        
        public string ClaimToAuthorize { get; }
    }
}
