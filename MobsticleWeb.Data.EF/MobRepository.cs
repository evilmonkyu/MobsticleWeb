using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobsticleWeb.Data;
using MobsticleWeb.Domain.Entities;

namespace MobsticleWeb.Data.EF
{
    public class MobRepository : Repository<Mob>, IMobRepository
    {
        public MobRepository(IDbSet<Mob> mobSet) : base(mobSet)
        {
        }

        public IEnumerable<Mob> GetMobs(string username)
        {
            return _set.Where(mob => mob.Users.Any(user => user.User.Name == username));
        }

    }
}
