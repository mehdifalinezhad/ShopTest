using Endpoint.Admin.Authorization.ClaimBasedAuthorization.MvcUserAccessClaims;
using System.Collections.ObjectModel;

namespace EndPoint.Admin.Authorization.ClaimBasedAuthorization.MvcUserAccessClaims
{
    public static class AllControllersClaimValues
    {
        public static readonly ReadOnlyCollection<(string claimValueEnglish, string claimValuePersian)> AllClaimValues;

        static AllControllersClaimValues()
        {
            var allClaimValues = new List<(string claimValueEnglish, string claimValuePersian)>();

            allClaimValues.AddRange(ApprenticeOnlineRequestControllerClaimValues.AllClaimValues);

            AllClaimValues = allClaimValues.AsReadOnly();
        }
    }
}
