using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using System.Data.Entity;

    using IService;

    using Models.Business;
    using Models.System;
    using Models.EnumEntity;

    public class WebAPiContextInitializer : DropCreateDatabaseIfModelChanges<WebApiContext>
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

            var user = new User() { UserName = "chenhan", NickName = "听暖", Email = "chen_han2008@sina.com", PassWord = "123456", Gender = Gender.Male, Level = 1 };
            context.Users.Add(user);

            context.SaveChanges();

            var areaControllerAction = new List<AreaControllerAction>() 
            { 
                new AreaControllerAction(){Controller="Home",Action="Index",Level=1},
                new AreaControllerAction(){Controller="Product",Action="GetAllProducts",  Level=1}
            };
            areaControllerAction.ForEach(p => context.AreaControllerAction.Add(p));

            var access = new List<AccessCaller>() 
            { 
            new AccessCaller(){ IP="192.156.87.90", DomainName= "www.baidu.com", CallerName="百度"},
            new AccessCaller(){ IP="216.156.87.90", DomainName= "www.sina.com", CallerName="新浪"},
            };
        }
    }
}
