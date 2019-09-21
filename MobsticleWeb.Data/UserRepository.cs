using MobsticleWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Data
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(string username);
    }
}
