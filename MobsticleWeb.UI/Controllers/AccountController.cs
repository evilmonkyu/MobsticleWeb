using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobsticleWeb.Constants;
using MobsticleWeb.Logic;
using MobsticleWeb.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MobsticleWeb.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RegistrationLogic _registrationLogic;

        public AccountController(RegistrationLogic registrationLogic, UserManager<IdentityUser> userManager)
        {
            _registrationLogic = registrationLogic;
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

            FormsAuthentication.SetAuthCookie(username, false);

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

            var result = await _registrationLogic.RegsiterUser(model.Username, model.Password);
            if (result.Count() > 0)
            {
                ViewBag.ErrorMessages = result;
                return View();
            }

            return Redirect("/RegistrationSuccessful");
        }
    }
}