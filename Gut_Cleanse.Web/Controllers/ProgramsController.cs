using Gut_Cleanse.Model;
using Gut_Cleanse.Service.ProgramsService;
using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                    if (!result.TestimonialPrograms.Any())
                        result.TestimonialPrograms.Add(new TestimonialModel());
                }
            }

            return View(model);
        }
        public IActionResult Create(ProgramModel model)
        {
            try
            {
                string currentUser = User.Identity.Name;
                if (model.Id > 0)
                {

                    bool isUpdated = _programsService.UpdateProgram(model, currentUser);
                    TempData["ToastrMessage"] = " updated successfully!";
                    TempData["ToastrType"] = "success";
                }
                else
                {
                   
                    _programsService.UpdateProgram(model, currentUser);
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
        [HttpPost]
        public IActionResult DeleteTestimonials(int testimonialId)
        {
            try
            {
                if (testimonialId > 0)
                {
                    _programsService.DeleteTestimonials(testimonialId); 
                    return Json(new { success = true });
                }
                return Json(new { success = false, error = "Invalid testimonial ID." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
    