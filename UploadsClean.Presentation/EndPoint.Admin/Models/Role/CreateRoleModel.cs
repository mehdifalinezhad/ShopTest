using System.ComponentModel.DataAnnotations;

namespace EndPoint.Admin.Models.Role
{
    public class CreateRoleModel
    {
        public CreateRoleModel()
        {
            ActionAndControllerNames = new List<ActionAndControllerName>();
        }

        [Required()]
        [Display(Name = "نام مقام")]
        public string RoleName { get; set; }
        public IList<ActionAndControllerName> ActionAndControllerNames { get; set; }
    }

    public class ActionAndControllerName
    {
        public string AreaName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public bool IsSelected { get; set; }
    }
}
