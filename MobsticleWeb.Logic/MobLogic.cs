using MobsticleWeb.Data;
using MobsticleWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Logic
{
    public class MobLogic
    {
        private IUnitOfWork _uof;

        public MobLogic(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public async virtual Task<List<string>> AddMob(string name, string username)
        {
            try
            {
                var user = _uof.Users.GetUser(username);

                var mob = new Mob { Name = name, Users = new List<MobUser> { new MobUser() { User = user } } };
                _uof.Mobs.Insert(mob);
                _uof.Commit();
            }
            catch
            {
                return new List<string> { "The mob could not be created" };
            }

            return new List<string>();
        }
    }
}
