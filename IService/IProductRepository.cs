using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    using Models;

    public interface IProductRepository:IDisposable
    {
        IQueryable<Product> GetAll();
        Product Get(int id);
        int Add(Product item);
        int Remove(int id);
        int Update(Product item);
    } 
}
