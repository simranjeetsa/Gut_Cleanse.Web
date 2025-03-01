using Gut_Cleanse.Model;
using Gut_Cleanse.Service.ProgramsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gut_Cleanse.Web.Controllers
{
    public class ProgramsController : Controller
    {

        private readonly IProgramsServices _programsService;
        public ProgramsController(IProgramsServices programsService)
        {
            _programsService = programsService;
        }

        public IActionResult Index()
        {
            var programs = _programsService.GetPrograms();
            return View(programs);
        }

        [Route("programs/one-one-gut-reset-revolution")]
        public IActionResult OneOneGutResetRevolution()
        {

            var testimonial = _programsService.GetTestimonialProgramsById(1);
            var programDetail = _programsService.GetProgramDetailByProgramId(1);
            var viewModel = new ProgramViewModel
            {
                TestimonialPrograms = testimonial,
                ProgramDetail = programDetail
            };
            return View(viewModel);
        }


        [Route("programs/gut-and-glory")]
        public IActionResult GutAndGlory()
        {
            var testimonial = _programsService.GetTestimonialProgramsById(1);
            var programDetail = _programsService.GetProgramDetailByProgramId(2);
            var viewModel = new ProgramViewModel
            {
                TestimonialPrograms = testimonial,
                ProgramDetail = programDetail
            };
            return View(viewModel);
        }

        [Route("programs/gut-intelligence-workshop")]
        public IActionResult GutIntelligenceWorkshop()
        {
            var testimonial = _programsService.GetTestimonialProgramsById(1);
            var programDetail = _programsService.GetProgramDetailByProgramId(3);
            var viewModel = new ProgramViewModel
            {
                TestimonialPrograms = testimonial,
                ProgramDetail = programDetail
            };
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            return View(_programsService.GetPrograms());
        }

        [HttpGet]
        public IActionResult Create(int Id)
        {
            ProgramModel model = new ProgramModel();


            if (Id != 0)
            {
                var result = _programsService.GetProgramWithDetails(Id).FirstOrDefault();

                if (result != null)
                {
                    // Populate the model with the program details
                    model.Description = result.Description;
                    model.Name = result.Name;
                    model.Amount = result.Amount;
                    model.StartDate = result.StartDate;
                    model.EndDate = result.EndDate;
                    model.ProgramDetail = result.ProgramDetail;
                    model.TestimonialPrograms = result.TestimonialPrograms;
                }
            }

            return View(model);
        }
        public IActionResult Create(ProgramModel model)
        {
            try
            {

                if (model.Id > 0)
                {
                    string currentUser = User.Identity.Name;

                    bool isUpdated = _programsService.UpdateProgram(model, currentUser);
                    TempData["ToastrMessage"] = " updated successfully!";
                    TempData["ToastrType"] = "success";
                }

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {

                TempData["ToastrMessage"] = ex.Message;
                TempData["ToastrType"] = "error";
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult AddTestimonial(int rowCount)
        {
            ProgramModel model= new ProgramModel();
            model.Count = rowCount;
            return PartialView("~/Views/Programs/Shared/_testimonial.cshtml",model);
        }
    }
}
