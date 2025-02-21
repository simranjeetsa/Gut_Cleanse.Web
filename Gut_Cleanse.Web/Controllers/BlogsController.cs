using Microsoft.AspNetCore.Mvc;

namespace Gut_Cleanse.Web.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Step_Approach()
        {
            return View();
        }
        public IActionResult Remedies()
        {
            return View();
        }
        
    }
}
