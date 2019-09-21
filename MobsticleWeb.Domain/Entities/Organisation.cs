using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Domain.Entities
{
    public class Organisation
    {
        public long Id { get; set; }


        public string Name { get; set; }

        public List<OrganisationUser> Users { get; set; }
    }
}