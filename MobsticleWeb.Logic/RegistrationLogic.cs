using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobsticleWeb.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Logic
{
    public class RegistrationLogic
    {
        private UserManager<IdentityUser> _userManager;

        public RegistrationLogic(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public virtual async Task<IEnumerable<string>> RegsiterUser(string username, string password)
        {
            var user = new IdentityUser(username);
            try
            {
                return (await _userManager.CreateAsync(user, password)).Errors;
            }
            catch (Exception)
            {
                return new[] { ErrorMessages.GenericRegistrationError };
            }
        }
    }
}
