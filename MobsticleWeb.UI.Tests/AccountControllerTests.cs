using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobsticleWeb.Constants;
using MobsticleWeb.Controllers;
using NSubstitute;

namespace MobsticleWeb.UI.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        private AccountController accountController;
        private IUserStore<IdentityUser> userStore;
        private UserManager<IdentityUser> userManager;

        [TestInitialize]
        public void Setup()
        {
            userStore = Substitute.For<IUserStore<IdentityUser>>();
            userManager = Substitute.For<UserManager<IdentityUser>>(userStore);
            accountController = new AccountController(userManager);
        }

        [TestMethod]
        public void ItRendersLoginPage()
        {
            var result = accountController.Login();
        }

        [TestMethod]
        public async Task ItLogsInSuccessfully()
        {
            var username = "test@example.com";
            var password = "Pass123";
            var result = await accountController.Login(username, password) as RedirectResult;
            Assert.AreEqual("/Home", result.Url);
        }

        [TestMethod]
        public async Task ItDisplaysErrorMessageOnIncorrectLogin()
        {
            var username = "test@example.com";
            var password = "Pass123";

            userManager.FindAsync(username, password).Returns(Task.FromResult<IdentityUser>(null));

            var result = (await accountController.Login(username, password)) as ViewResult;

            Assert.AreEqual(ErrorMessages.BadUsernamePassword, result.ViewBag.ErrorMessage);
        }

        [TestMethod]
        public async Task ItRendersRegistrationPage()
        {
            var result = accountController.Register();
        }
    }
}