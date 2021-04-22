using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marketplace.Models;
using Marketplace.Models.AccountViewModels;
using Marketplace.Data;
using Marketplace.Services;
using System;


namespace Marketplace.Controllers
{
    [Authorize(Policy="RequireElevatedRole")]
    public class AdminController : Controller
    {  
        public AdminService AdminService;

        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        
        private readonly ILogger _logger;
        private UserService userService;
        public AdminController(AdminService AdminService, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, ILogger<AccountController> logger, UserService userService)
        {
            this.AdminService = AdminService;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
            this.userService = userService;
        }
        
        public IActionResult Index()
        {
            ViewBag.ActiveBids= AdminService.GetModulesWithBids();
            ViewBag.ViewInstructors= AdminService.ViewInstructors();
            ViewBag.AmountOfBids= AdminService.GetAmountOfBids();
            ViewBag.ViewModules= AdminService.ViewModules();
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded && this.userService.AdminExists(model.Email))
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Index", "Admin");
                }
                // if (result.IsLockedOut)
                // {
                //     _logger.LogWarning("User account locked out.");
                //     return RedirectToAction(nameof(Lockout));
                // }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("~/Views/Account/Login.cshtml", model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View("~/Views/Account/Login.cshtml", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = new AdministratorModel { Email = model.Email, Name = model.Name };
                user.UserName = model.Email;
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "AdministratorRole");
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    // var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    // await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToAction("Index", "Admin");
                }
                
            }

            // If we got this far, something failed, redisplay form
            return View("~/Views/Account/Register.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Login", "Admin");
        }


        [Authorize(Policy="RequireAdministratorRole")]
        public IActionResult EditInstructor(string InstructorId)
        {
            InstructorModel instructorToEdit= AdminService.GetInstructorById(InstructorId);
            return View(instructorToEdit);
        }

        [HttpPost]
        public IActionResult EditInstructor(InstructorModel InstructorToEdit)
        {
            AdminService.EditInstructor(InstructorToEdit);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult EditModule(int ModuleId)
        {
            ModuleModel moduleToEdit= AdminService.GetModuleById(ModuleId);
            return View(moduleToEdit);
        }

        [HttpPost]
        public IActionResult EditModule(ModuleModel ModuleToEdit)
        {
            AdminService.EditModule(ModuleToEdit);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult ViewBidders(int ModuleId)
        {
            ViewBag.ViewBidders= AdminService.GetInstructorsThatBid(ModuleId);
            return View();
        }

        public IActionResult AcceptBid(int BidId)
        {
            AdminService.AcceptBid(BidId);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult DenyBid(int BidId)
        {
            AdminService.DenyBid(BidId);
            return RedirectToAction("Index", "Admin");
        }
    }
}