using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeKeeper.Web.Models;
using TimeKeeper.Web.Models.ViewModels;

namespace TimeKeeper.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "TimeKeeper");
            }
            var model = new LoginViewModel();
            return View(model);
        }

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "TimeKeeper");
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signinManager.PasswordSignInAsync(user, model.Password, true, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "TimeKeeper");
                    }
                    else
                    {
                        ModelState.AddModelError("password", "E-mail and password does not match.");
                    }
                }
                else
                {
                    ModelState.AddModelError("email", "E-mail and password does not match.");
                }
            }
            return RedirectToAction("Index", "Account", model);
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync().ConfigureAwait(false);
                await _signinManager.SignOutAsync().ConfigureAwait(false);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
