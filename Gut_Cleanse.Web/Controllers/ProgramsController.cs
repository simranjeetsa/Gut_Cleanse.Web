using Microsoft.AspNetCore.Mvc;

namespace Gut_Cleanse.Web.Controllers
{
    public class ProgramsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("programs/one-one-gut-reset-revolution")]
        public IActionResult OneOneGutResetRevolution()
        {
            return View();
        }

        [Route("programs/gut-and-glory")]
        public IActionResult GutAndGlory()
        {
            return View();
        }

        [Route("programs/gut-intelligence-workshop")]
        public IActionResult GutIntelligenceWorkshop()
        {
            return View();
        }
    }
}
