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
    public class LoginLogic
    {
        private UserManager<IdentityUser> userManager;

        public LoginLogic(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async virtual Task<List<string>> Login(string username, string password)
        {           
            return await userManager.FindAsync(username, password) == null ? new List<string> { ErrorMessages.BadUsernamePassword } : null;
        }
    }
}
