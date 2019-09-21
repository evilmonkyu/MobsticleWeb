using MobsticleWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Data.EF
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDbSet<User> set) : base(set)
        {
        }

        public User GetUser(string username)
        {
            return _set.Single(x => x.Email == username);
        }
    }
}
