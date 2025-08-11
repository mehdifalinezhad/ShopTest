using EndPoint.Admin.Authorization.ClaimBasedAuthorization.MvcUserAccessClaims;
using System.Collections.ObjectModel;

namespace Endpoint.Admin.Authorization.ClaimBasedAuthorization.MvcUserAccessClaims
{
    public class ApprenticeOnlineRequestControllerClaimValues
    {

        public const string _ApprenticeOnlineRequest_Index = nameof(_ApprenticeOnlineRequest_Index);
        public const string _ApprenticeOnlineRequest_IndexPersian = "درخواست آنلاین";


        public const string ApprenticeOnlineRequestIndex = nameof(ApprenticeOnlineRequestIndex);
        public const string ApprenticeOnlineRequestIndexPersian = "صفحه اصلی درخواست آنلاین";


        public const string ApprenticeOnlineRequestAddOrEdit = nameof(ApprenticeOnlineRequestAddOrEdit);
        public const string ApprenticeOnlineRequestAddOrEditPersian = "ایجاد و مشاهده درخواست";


        public static readonly ReadOnlyCollection<(string claimValueEnglish, string claimValuePersian)> AllClaimValues;

        static ApprenticeOnlineRequestControllerClaimValues()
        {
            AllClaimValues =
                MvcClaimValuesUtilities.GetPersianAndEnglishClaimValues(typeof(ApprenticeOnlineRequestControllerClaimValues))
                    .ToList()
                    .AsReadOnly();
        }
    }
}
