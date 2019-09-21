using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobsticleWeb.Data.EF
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IDbSet<T> _set;

        public Repository(IDbSet<T> set)
        {
            _set = set;
        }

        public void Delete(T entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public T GetByID(object id)
        {
            return _set.Find(id);
        }

        public void Insert(T entity)
        {
            _set.Add(entity);
        }

        public void Update(T entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
