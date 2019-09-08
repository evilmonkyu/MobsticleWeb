using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace MobsticleWeb.Logic.Tests
{
    [TestClass]
    public class RegistrationLogicTests
    {
        private RegistrationLogic registrationLogic;
        private IUserStore<IdentityUser> userStore;
        private UserManager<IdentityUser> userManager;

        [TestInitialize]
        public void Setup()
        {
            userStore = Substitute.For<IUserStore<IdentityUser>>();
            userManager = Substitute.For<UserManager<IdentityUser>>(userStore);
            registrationLogic = new RegistrationLogic(userManager);
        }

        [TestMethod]
        public async Task ItSuccessfullyRegistersUser()
        {
            var username = "test@example.com";
            var password = "Pass123";
            
            userManager.CreateAsync(Arg.Any<IdentityUser>(), password).Returns(Task.FromResult(IdentityResult.Success));

            var result = await registrationLogic.RegsiterUser(username, password);

            Assert.AreEqual(0, result.Count());

            await userManager.Received().CreateAsync(Arg.Is<IdentityUser>(u => u.UserName == username), password);
        }
    }
}
