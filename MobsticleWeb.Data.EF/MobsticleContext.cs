using MobsticleWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Data.EF
{
    public class MobsticleContext : DbContext
    {
        public IDbSet<Mob> Mobs { get; set; }
        public IDbSet<User> Users { get; set; }
    }
}
