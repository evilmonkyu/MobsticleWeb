using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobsticleWeb.Constants;
using MobsticleWeb.Controllers;
using MobsticleWeb.Models.Account;
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

        [TestMethod]
        public async Task ItSuccessfullyRegistersUser()
        {
            var username = "test@example.com";
            var password = "Pass123";
            var model = new RegistrationModel { Username = username, Password = password };

            userManager.CreateAsync(Arg.Any<IdentityUser>(), password).Returns(Task.FromResult(IdentityResult.Success));

            var result = await accountController.Register(model) as RedirectResult;

            Assert.AreEqual("/RegistrationSuccessful", result.Url);

            await userManager.Received().CreateAsync(Arg.Is<IdentityUser>(u => u.UserName == username), password);
        }

        [TestMethod]
        public async Task ItFailsToRegistersUserIfModelIsInvalid()
        {
            var username = "test@example.com";
            var password = "Pass123";

            var model = new RegistrationModel { Username = username, Password = password };

            accountController.ModelState.AddModelError("x", "Bad message");
            accountController.ModelState.AddModelError("y", "Bad message2");

            var result = await accountController.Register(model) as ViewResult;

            CollectionAssert.AreEqual(new[] { "Bad message", "Bad message2" }, (result.ViewBag.ErrorMessages as IEnumerable<string>).ToList());
        }

        [TestMethod]
        public async Task ItFailsToRegisterUserIfUserManagerFails()
        {
            var username = "test@example.com";
            var password = "Pass123";
            var model = new RegistrationModel { Username = username, Password = password };

            userManager.CreateAsync(Arg.Any<IdentityUser>(), password).Returns(Task.Run((Func<Task<IdentityResult>>)(() => throw new ApplicationException())));

            var result = await accountController.Register(model) as ViewResult;

            CollectionAssert.AreEqual(new[] { ErrorMessages.GenericRegistrationError }, (result.ViewBag.ErrorMessages as IEnumerable<string>).ToList());
        }

        [TestMethod]
        public async Task ItFailsToRegisterUserIfUserManagerReturnsError()
        {
            var username = "test@example.com";
            var password = "Pass123";
            var model = new RegistrationModel { Username = username, Password = password };

            userManager.CreateAsync(Arg.Any<IdentityUser>(), password).Returns(Task.FromResult(new IdentityResult("An error")));

            var result = await accountController.Register(model) as ViewResult;

            CollectionAssert.AreEqual(new[] { "An error" }, (result.ViewBag.ErrorMessages as IEnumerable<string>).ToList());
        }
    }
}