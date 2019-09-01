using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobsticleWeb.Constants;
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
    }
}