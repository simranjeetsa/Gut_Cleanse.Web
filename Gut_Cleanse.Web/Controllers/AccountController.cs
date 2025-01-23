using Gut_Cleanse.Data;
using Gut_Cleanse.Model;
using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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
        public IActionResult Login(string ReturnUrl)
        {
            LoginViewModel model = new LoginViewModel();
            model.ReturnUrl = ReturnUrl;
            if (User.Identity.IsAuthenticated && HttpContext != null && HttpContext.Session.GetString("User") != null)
            {
                if (string.IsNullOrEmpty(ReturnUrl))
                    return RedirectToAction("Index", "User");
                else
                    return Redirect(ReturnUrl);
            }
            return View(model);
        }

        // POST Login action
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var userInfo = _userService.GetUserByUserId(user.Id);
                        HttpContext.Session.SetString("User", Newtonsoft.Json.JsonConvert.SerializeObject(userInfo));
                        if (string.IsNullOrEmpty(model.ReturnUrl))
                            return RedirectToAction("Index", "User");
                        else
                            return Redirect(model.ReturnUrl);
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
            HttpContext.Session.Clear();
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
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
    }
}
