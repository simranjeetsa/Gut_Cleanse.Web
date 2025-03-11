using Gut_Cleanse.Model;
using Gut_Cleanse.Service.CommonService;
using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Text;

namespace Gut_Cleanse.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        readonly IUserService userService;
        private readonly ICommonService _commonService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CustomerController(IUserService _userService, ICommonService commonService, IWebHostEnvironment webHostEnvironment)
        {
            userService = _userService;
            _commonService = commonService;
            _webHostEnvironment = webHostEnvironment;
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

        public IActionResult Ebook(int id)
        {
            var user = _commonService.GetCurrentUserInfo();
            var userId = 0;
            if (user != null)
            {
                userId = user.Id;
            }
            var result = _commonService.IsEbookAccess(id, userId);

            if (result)
            {
                return View();
            }
            else
            {
                return PartialView("_AccessDenied");
            }
        }

        public ActionResult ShowPdf()
        {
            var filePath = _webHostEnvironment.WebRootPath + "\\Assets\\ebook\\program.pdf";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf");
        }
    }
}
