using MobsticleWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Data
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get;  }

        IMobRepository Mobs { get; }

        void Commit();
    }
}
