using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    using IService;

    using Models;

    using Service;

    public class ProductController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        // GET api/Product
        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = repository.GetAll();
            return products;
        }

        // GET api/Product/5
        public Product GetProductByID(int id)
        {
            Product product = repository.Get(id);
            if (product == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return product;
        }

        public IEnumerable<Product> GetProductByCategory(string category)
        {
            return repository.GetAll().Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }
        // PUT api/Product/5
        public HttpResponseMessage PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != product.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                if (repository.Update(product) <= 0) ; return Request.CreateErrorResponse(HttpStatusCode.NotFound, product.ToString());
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Product
        public HttpResponseMessage PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                if (repository.Add(product) <= 0) ; return Request.CreateErrorResponse(HttpStatusCode.NotFound, product.ToString());
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, product);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = product.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Product/5
        public HttpResponseMessage DeleteProduct(int id)
        {
            Product product = repository.Get(id);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                if (repository.Remove(id) <= 0) ; return Request.CreateErrorResponse(HttpStatusCode.NotFound, product.ToString());
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

    }
}