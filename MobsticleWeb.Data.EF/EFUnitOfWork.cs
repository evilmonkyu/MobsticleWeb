using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobsticleWeb.Domain.Entities;

namespace MobsticleWeb.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {

        private MobsticleContext _context;

        public EFUnitOfWork(MobsticleContext context)
        {
            _context = context;
            Mobs = new MobRepository(context.Mobs);
            Users = new UserRepository(context.Users);
        }

        public IUserRepository Users { get; private set; }

        public IMobRepository Mobs { get; private set; }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
