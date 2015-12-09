using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IService;
namespace Service
{
    using System.Data;
    using System.Data.Entity;

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly WebApiContext db = new WebApiContext();

        private IDbSet<TEntity> dbset
        {
            get
            {
                return db.Set<TEntity>();
            }

        }

        public IQueryable<TEntity> GetAll()
        {
            return dbset;
        }

        public TEntity Get(TKey id)
        {
            return dbset.Find(id);
        }

        public int Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("AddEntity", typeof(TEntity).Name + "为空");
            }
            dbset.Add(item);
            return db.SaveChanges();
        }

        public int Remove(TKey id)
        {
            TEntity entity = Get(id);
            if (entity == null)
            {
                throw new ArgumentNullException("RemoveEntity", "获取不到" + typeof(TEntity).Name);
            }
            dbset.Remove(entity);
            return db.SaveChanges();
        }

        public int Update(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("UpdateEntity", typeof(TEntity).Name + "为空");
            }
            dbset.Attach(item);
            db.Entry(item).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Repository()
        {
            // TODO: Complete member initialization
        }
    }
}
