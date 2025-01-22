using Gut_Cleanse.Model;
using Gut_Cleanse.Service.CommonService;
using Gut_Cleanse.Service.User;
using Gut_Cleanse.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gut_Cleanse.Web.Controllers
{
    [Authorize]
    //[CheckSessionIsAvailable]
    public class UserController : Controller
    {
        readonly IUserService userService;
        readonly ICommonService commonService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserController(IUserService _userService, ICommonService _commonService, IWebHostEnvironment webHostEnvironment)
        {
            userService = _userService;
            commonService = _commonService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(userService.GetUsers());
        }
        [HttpGet]
        public IActionResult Create(int Id)
        {
            UserModel result = new UserModel();
            result.DOB = DateOnly.FromDateTime(DateTime.Now);
            if (Id != 0)
                result = userService.GetUserById(Id);
            result.Gender = string.IsNullOrEmpty(result.Gender) ? "Male" : result.Gender;
            result.Countries = commonService.GetCountries();
            result.States = result.CountryId != null ? commonService.GetStatesByCountryId((int)result.CountryId) : new List<StateModel>();
            result.Cities = result.StateId != null ? commonService.GetCitiesByStateId((int)result.StateId) : new List<CityModel>();
            return View(result);
        }
        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            try
            {
                var file = HttpContext.Request.Form.Files.FirstOrDefault();
                if (file != null && file.Length > 0)
                {
                    var directory = _webHostEnvironment.WebRootPath + "\\Assets\\ProfilePic";
                    var extension = Path.GetExtension(file.FileName);
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + Guid.NewGuid();
                    var filePath = Path.Combine(directory, fileName + extension);

                    if (!System.IO.Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.ProfilePicture = "/Assets/ProfilePic/" + fileName + extension;
                }
                if (model.Id > 0)
                {
                    userService.UpdateUser(model);
                    TempData["ToastrMessage"] = "User updated successfully!";
                    TempData["ToastrType"] = "success";
                }
                else
                {
                    userService.AddUser(model);
                    TempData["ToastrMessage"] = "User created successfully!";
                    TempData["ToastrType"] = "success";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                model.Countries = commonService.GetCountries();
                model.States = model.CountryId != null ? commonService.GetStatesByCountryId((int)model.CountryId) : new List<StateModel>();
                model.Cities = model.StateId != null ? commonService.GetCitiesByStateId((int)model.StateId) : new List<CityModel>();
                TempData["ToastrMessage"] = ex.Message;
                TempData["ToastrType"] = "error";
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    userService.Delete(id);
                    TempData["ToastrMessage"] = "User deleted successfully!";
                    TempData["ToastrType"] = "success";
                }
            }
            catch (Exception ex)
            {
                TempData["ToastrMessage"] = ex.Message;
                TempData["ToastrType"] = "error";
            }
            

            return RedirectToAction("Index");

        }
    }
}
