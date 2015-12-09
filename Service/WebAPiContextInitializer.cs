using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using System.Data.Entity;

    using IService;

    using Models;

    public  class WebAPiContextInitializer:DropCreateDatabaseIfModelChanges<WebApiContext>
    {
        static readonly IProductRepository repository = new ProductRepository();

        protected override void Seed(WebApiContext context)
        {
              var products = new List<Product>()
              { 
                new Product() { ProductName = "Tomato Soup", Category = "Groceries", Price = 1.39M, ActualCost = .99M }, 
                new Product() { ProductName = "Hammer", Category = "Toys", Price = 16.99M, ActualCost = 10 }, 
                new Product() { ProductName = "Yo yo",  Category = "Hardware", Price = 6.99M, ActualCost = 2.05M } 
            }; 

            products.ForEach(p => context.Products.Add(p)); 
            context.SaveChanges(); 

            var order = new Order() { Customer = "Bob" }; 
            var od = new List<OrderDetail>() 
            { 
                new OrderDetail() { Product = products[0], Quantity = 2, Order = order},
                new OrderDetail() { Product = products[1], Quantity = 4, Order = order }
            }; 
            context.Orders.Add(order);
            od.ForEach(o => context.OrderDetails.Add(o)); 

            context.SaveChanges(); 
        }
    }
}
