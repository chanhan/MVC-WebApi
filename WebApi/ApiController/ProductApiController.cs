using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IService;
using Service;
using Models.Business;
namespace WebApi.Cont
{
    public class ProductApiController : ApiController
    {
        IRepository<Product, int> repository = new Repository<Product, int>();
        private IQueryable<ProductDTO> GetAll()
        {
            return repository.GetAll().Select(p => new ProductDTO()
            {
                Id = p.Id,
                Category = p.Category,
                Price = p.Price,
                ProductName = p.ProductName
            });
        }
        public IEnumerable<ProductDTO> GetProduct()
        {
            return GetAll().ToList();
        }
        public ProductDTO GetProductByID(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }
    }
}
