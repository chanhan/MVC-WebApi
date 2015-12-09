﻿using Models.Business;
using System.Data.Entity;
using Models.System;

namespace Service
{
    public class WebApiContext : DbContext
    {
        // 您可以向此文件中添加自定义代码。更改不会被覆盖。
        // 
        // 如果您希望只要更改模型架构，Entity Framework
        // 就会自动删除并重新生成数据库，则将以下
        // 代码添加到 Global.asax 文件中的 Application_Start 方法。
        // 注意: 这将在每次更改模型时销毁并重新创建数据库。
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<WebApi.Models.WebApiContext>());

        public WebApiContext() : base("name=WebApiContext")
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
