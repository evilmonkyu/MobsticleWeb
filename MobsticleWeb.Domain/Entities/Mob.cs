using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Domain.Entities
{
    public class Mob
    {
        public string Name { get; set; }

        public List<MobUser> Users { get; set; }
    }
}