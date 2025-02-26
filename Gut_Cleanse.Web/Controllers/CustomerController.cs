using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gut_Cleanse.Web.Controllers
{
    public class CustomerController : Controller
    {
        readonly IUserService userService;
        public CustomerController(IUserService _userService)
        {
            userService = _userService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(userService.GetUsers().Where(x => x.RoleName == "Customer"));
        }
    }
}
