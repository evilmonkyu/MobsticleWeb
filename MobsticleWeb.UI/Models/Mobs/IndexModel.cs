using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobsticleWeb.Domain.Entities;

namespace MobsticleWeb.Models.Mobs
{
    public class IndexModel
    {
        public int Page { get; set; }

        public int PageCount { get; set; }

        public List<Mob> Mobs { get; set; }
    }
}