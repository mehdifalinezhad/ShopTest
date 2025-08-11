using System.Collections.ObjectModel;

namespace EndPoint.Admin.Authorization.ClaimBasedAuthorization.MvcUserAccessClaims
{
    public static class ResetPasswordControllerClaimValues
    {
        public const string ResetPasswordIndex = nameof(ResetPasswordIndex); 
        public const string ResetPasswordIndexPersian = "صفحه اصلی بازنشانی کلمه عبور";

        public const string _ResetPassword_Index = nameof(_ResetPassword_Index);
        public const string _ResetPassword_IndexPersian = " بازنشانی کلمه عبور ";



        public static readonly ReadOnlyCollection<(string claimValueEnglish, string claimValuePersian)> AllClaimValues;

        static ResetPasswordControllerClaimValues()
        {
            AllClaimValues =
                MvcClaimValuesUtilities.GetPersianAndEnglishClaimValues(typeof(ResetPasswordControllerClaimValues))
                    .ToList()
                    .AsReadOnly();
        }
    }
}
