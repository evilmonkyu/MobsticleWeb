using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobsticleWeb.Constants;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Logic.Tests
{
    [TestClass]
    public class LoginLogicTests
    {
        private LoginLogic loginLogic;
        private IUserStore<IdentityUser> userStore;
        private UserManager<IdentityUser> userManager;

        [TestInitialize]
        public void Setup()
        {
            userStore = Substitute.For<IUserStore<IdentityUser>>();
            userManager = Substitute.For<UserManager<IdentityUser>>(userStore);
            loginLogic = new LoginLogic(userManager);
        }

        [TestMethod]
        public async Task ItCanLogInSuccessfully()
        {
            var username = "test@example.com";
            var password = "Pass123";

            userManager.FindAsync(username, password).Returns(new IdentityUser());
            var result = await loginLogic.Login(username, password);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public async Task ItFailsToLoginWithWrongPassword()
        {
            var username = "test@example.com";
            var password = "Pass123";
            var result = await loginLogic.Login(username, password);

            Assert.AreEqual(ErrorMessages.BadUsernamePassword, result[0]);
        }
    }
}
