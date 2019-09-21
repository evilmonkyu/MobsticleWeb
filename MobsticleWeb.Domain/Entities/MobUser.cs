using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Domain.Entities
{
    public class MobUser
    {
        public long Id { get; set; }

        public User User { get; set; }
    }
}