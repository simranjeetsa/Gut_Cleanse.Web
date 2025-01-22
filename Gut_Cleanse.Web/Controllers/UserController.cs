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
        public UserController(IUserService _userService, ICommonService _commonService)
        {
            userService = _userService;
            commonService = _commonService;
        }
        public IActionResult Index()
        {
            return View(userService.GetUsers());
        }
        [HttpGet]
        public IActionResult Create(int Id)
        {
            UserModel result = new UserModel();
            result.Gender = "Male";
            result.DOB = DateOnly.FromDateTime(DateTime.Now);
            if (Id != 0)
                result = userService.GetUserById(Id);
            result.Countries = commonService.GetCountries();
            result.States = commonService.GetStatesByCountryId(result.CountryId);
            result.Cities = commonService.GetCitiesByStateId(result.StateId);
            return View(result);
        }
        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            try
            {
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
                model.States = commonService.GetStatesByCountryId(model.CountryId);
                model.Cities = commonService.GetCitiesByStateId(model.StateId);
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
