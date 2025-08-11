using System.Collections.ObjectModel;

namespace EndPoint.Admin.Authorization.ClaimBasedAuthorization.MvcUserAccessClaims
{
    public static class ManageUserControllerClaimValues
    {
        public const string ManageUserIndex = nameof(ManageUserIndex); 
        public const string ManageUserIndexPersian = "صفحه اصلی مدیریت سطح دسترسی";

        public const string _ManageUser_Index = nameof(_ManageUser_Index);
        public const string _ManageUser_IndexPersian = " مدیریت سطح دسترسی";

        public const string ManageUserEdit = nameof(ManageUserEdit);
        public const string ManageUserEditPersian = "ویرایش کاربر";

        public const string ManageUserAddUserToRole = nameof(ManageUserAddUserToRole);
        public const string ManageUserAddUserToRolePersian = "اضافه کردن نقش به کاربر";

        public const string ManageUserRemoveUserFromRole = nameof(ManageUserRemoveUserFromRole);
        public const string ManageUserRemoveUserFromRolePersian = " حذف کاربر از نقش";


        public const string ManageUserDeleteUser = nameof(ManageUserDeleteUser);
        public const string ManageUserDeleteUserPersian = "حذف کاربر ";

        public const string ManageUserAddUserToClaim = nameof(ManageUserAddUserToClaim);
        public const string ManageUserAddUserToClaimPersian = "اضافه کردن اختیارات کاربر ";


        public const string ManageUserRemoveUserFromClaim = nameof(ManageUserRemoveUserFromClaim);
        public const string ManageUserRemoveUserFromClaimPersian = "حذف اختیارات کاربر ";

        public const string ManageUserUpdateSecurityStamp = nameof(ManageUserUpdateSecurityStamp);
        public const string ManageUserUpdateSecurityStampPersian = "به روزرسانی فوری سطح دسترسی";

        public static readonly ReadOnlyCollection<(string claimValueEnglish, string claimValuePersian)> AllClaimValues;

        static ManageUserControllerClaimValues()
        {
            AllClaimValues =
                MvcClaimValuesUtilities.GetPersianAndEnglishClaimValues(typeof(ManageUserControllerClaimValues))
                    .ToList()
                    .AsReadOnly();
        }
    }
}
