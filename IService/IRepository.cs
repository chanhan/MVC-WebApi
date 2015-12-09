using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IRepository<TEntity,TKey> : IDisposable where TEntity:class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(TKey id);
        int Add(TEntity item);
        int Remove(TKey id);
        int Update(TEntity item);
    }
}
