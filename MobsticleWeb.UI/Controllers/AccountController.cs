using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobsticleWeb.Constants;
using MobsticleWeb.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MobsticleWeb.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindAsync(username, password);

            if (user == null)
            {
                ViewBag.ErrorMessage = ErrorMessages.BadUsernamePassword;
                return View();
            }

            return Redirect("/Home");
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage));
                return View(model);
            }

            var user = new IdentityUser(model.Username);
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    ViewBag.ErrorMessages = result.Errors;
                    return View(model);
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessages = new[] { ErrorMessages.GenericRegistrationError };
                return View(model);
            }

            return Redirect("/RegistrationSuccessful");
        }
    }
}