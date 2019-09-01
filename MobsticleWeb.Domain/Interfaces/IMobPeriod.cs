using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Domain.Interfaces
{
    public interface IMobPeriod
    {
        DateTime Start { get; set; }

        DateTime End { get; set; }
    }
}