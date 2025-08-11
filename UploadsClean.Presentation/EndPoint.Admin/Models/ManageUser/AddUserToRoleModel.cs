namespace CarpetCleaning.Web.Models.ManageUser
{
    public class AddUserToRoleModel
    {
        #region Constructor

        public AddUserToRoleModel()
        {
            UserRoles = new List<UserRolesModel>();
        }

        public AddUserToRoleModel(string userId, IList<UserRolesModel> userRoles)
        {
            UserId = userId;
            UserRoles = userRoles;
        }


        #endregion



        public string UserId { get; set; }

        public IList<UserRolesModel> UserRoles { get; set; }
    }

    public class UserRolesModel
    {

        #region Constructor

        public UserRolesModel()
        {
        }

        public UserRolesModel(string roleName)
        {
            RoleName = roleName;
        }


        #endregion

        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
