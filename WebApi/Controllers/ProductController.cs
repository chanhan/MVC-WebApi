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
    using System.Collections;

    using IService;

    using Models.Business;

    using Service;

    public class ProductController : ApiController
    {
        static readonly IRepository<Product, int> rep = new Repository<Product, int>();

        // GET api/Product
        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = rep.GetAll();
            return products;
        }

        // GET api/Product/5
        public Product GetProductByID(int id)
        {
            Product product = rep.Get(id);
            if (product == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return product;
        }

        public IEnumerable<Product> GetProductByCategory(string category)
        {
            return rep.GetAll().Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
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
                if (rep.Update(product) <= 0)  
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, product.ToString()); 
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // POST api/Product
        public HttpResponseMessage PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                if (rep.Add(product) <= 0) 
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, product.ToString());
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
            Product product = rep.Get(id);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                if (rep.Remove(id) <= 0) return Request.CreateErrorResponse(HttpStatusCode.NotFound, product.ToString());
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

    }
}