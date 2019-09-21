using MobsticleWeb.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Domain.Entities
{
    public class Pause : IMobPeriod
    {
        public long Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}