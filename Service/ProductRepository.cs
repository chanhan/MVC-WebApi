using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using IService;

    using Models.Business;
    using System.Data;

    public class ProductRepository : IProductRepository
    {
        private WebApiContext db = new WebApiContext();

        public IQueryable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public int Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("AddProduct", "Product为空");
            }
            db.Products.Add(item);
            return db.SaveChanges();
        }

        public int Remove(int id)
        {
            Product product = Get(id);
            if (product == null)
            {
                throw new ArgumentNullException("RemoveProduct", "获取不到Product");
            }
            db.Products.Remove(product);
            return db.SaveChanges();
        }

        public int Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("UpdateProduct", "Product为空");
            }
            db.Products.Attach(item);
            db.Entry(item).State = EntityState.Modified;
           return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
