using Gut_Cleanse.Data;
using Gut_Cleanse.Model;
using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gut_Cleanse.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        readonly IUserService _userService;

        public AccountController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        // Login action
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST Login action
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var userInfo = _userService.GetUserByUserId(user.Id);
                        HttpContext.Session.SetString("User", Newtonsoft.Json.JsonConvert.SerializeObject(userInfo));
                        return RedirectToAction("Index", "User");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User does not exist.");
                }
            }
            return View(model);
        }

        // Logout action

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        // Register action (optional)
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST Register action (optional)
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Password != model.ConfirmPassword)
                    {
                        throw new Exception(message: "Password and Confirm Password doesn't match!");
                    }
                    var user = new ApplicationUser { Email = model.Email, UserName = model.Email };
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        var aspNetUser = await _userManager.FindByEmailAsync(model.Email);
                        if (aspNetUser != null)
                        {
                            var newUser = new UserModel()
                            {
                                Email = model.Email,
                                AspNetUserId = aspNetUser.Id,
                                IsDeleted = false,
                                IsLocked = true,
                            };

                            _userService.AddUser(newUser);
                        }
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            
            return View(model);
        }
    }
}
