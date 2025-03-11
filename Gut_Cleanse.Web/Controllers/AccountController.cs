using Gut_Cleanse.Data;
using Gut_Cleanse.Model;
using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;

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
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                        var isCustomer = await _userManager.IsInRoleAsync(user, "Customer");
                        var userInfo = _userService.GetUserByUserId(user.Id);
                        HttpContext.Session.SetString("User", Newtonsoft.Json.JsonConvert.SerializeObject(userInfo));

                        if (isAdmin)
                        {
                            return RedirectToAction("Index", "User");
                        }
                        else if (isCustomer)
                        {
                            // Redirect customer to their specific page
                            return RedirectToAction("PaymentInfo", "Payment");
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(model.ReturnUrl))
                            {
                                return RedirectToAction("WelcomeUser", "Dashboard");
                            }
                            else
                            {
                                return Redirect(model.ReturnUrl);
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
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
                       //await _roleManager.CreateAsync(new IdentityRole("Customer"));
                        //await _userManager.AddToRoleAsync(user, "Customer");

                        var aspNetUser = await _userManager.FindByEmailAsync(model.Email);
                        await _userManager.AddToRoleAsync(aspNetUser, "Admin");
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
