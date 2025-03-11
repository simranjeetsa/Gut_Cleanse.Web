using Gut_Cleanse.Data.Tables;
using Gut_Cleanse.Model;
using Gut_Cleanse.Service.ProgramsService;
using Gut_Cleanse.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gut_Cleanse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProgramsServices _programsService;

        public HomeController(ILogger<HomeController> logger, IProgramsServices programsService)
        {
            _logger = logger;
            _programsService = programsService;
        }

        public IActionResult Index()
         {
            var testimonial = _programsService.GetTestimonialProgramsById(1).OrderByDescending(x => x.Id);
            var viewModel = new ProgramViewModel
            {
                TestimonialPrograms = testimonial,
            };

            return View(viewModel);  // Pass the viewModel to the view
        }

        [Route("privacy-policy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("term-and-condition")]
        public IActionResult TermAndCondition()
        {
            return View();
        }

        [Route("refund-policy")]
        public IActionResult RefundPolicy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Process()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
