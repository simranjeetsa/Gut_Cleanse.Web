using Gut_Cleanse.Model;
using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
        public IActionResult ExportToCSV()
        {
          
            IEnumerable<UserModel> users = userService.GetUsers().Where(x => x.RoleName == "Customer");
            var sb = new StringBuilder();
          
            sb.AppendLine("Name,Contact No.,Email");

            foreach (var user in users)
            {
                sb.AppendLine($"{user.FirstName} {user.LastName},{user.ContactNumber},{user.Email}");
            }
            var fileName = "customers.csv";

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", fileName);
        }
    }
}
