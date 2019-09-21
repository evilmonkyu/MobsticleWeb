using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Data
{
    public interface IRepository<T> where T : class
    {
        void Delete(T entityToDelete);
        void Delete(object id);
        T GetByID(object id);
        void Insert(T entity);
        void Update(T entityToUpdate);
    }
}
