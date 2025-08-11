namespace CarpetCleaning.Web.Models.ManageUser
{
    public class AddOrRemoveClaimModel
    {
        #region Constructor

     
        public AddOrRemoveClaimModel(string userId, IList<ClaimsModel> userClaims)
        {
            UserId = userId;
            UserClaims = userClaims;
			UserClaims = new List<ClaimsModel>();
		}

        #endregion


        public string UserId { get; set; }
        public IList<ClaimsModel> UserClaims { get; set; }
    }

    public class ClaimsModel
    {

        #region Constructor


        public ClaimsModel(string claimType, string persionClaimType)
        {
            ClaimType = claimType;
            PersionClaimType = persionClaimType;
        }

        #endregion

        public string ClaimType { get; set; }
        public string PersionClaimType { get; set; }
        public bool IsSelected { get; set; }
    }
}
