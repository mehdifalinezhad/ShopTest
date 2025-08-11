using System.ComponentModel.DataAnnotations;

namespace EndPoint.Admin.Models.ManageUser
{
    public class IndexModel
    {
        public string Id { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }
}
