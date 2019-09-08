using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            return null;
        }
    }
}
