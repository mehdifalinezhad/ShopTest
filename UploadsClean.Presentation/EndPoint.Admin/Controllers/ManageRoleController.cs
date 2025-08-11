using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Admin.Controllers
{
    public class ManageRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
