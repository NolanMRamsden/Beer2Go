using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Data.Models;
using Orders.Data.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests
{
    public abstract class OrderTest
    {
        public static readonly OrderDataConfiguration cacheConfiguration = new OrderDataConfiguration()
        {
            Type = eStorageType.MySql,
            FilePath = @"C:\Users\Nolan\Documents\Beer Truck Research\OrderDB.xml",
            ConnectionString = "Database=TheBar;Data Source=localhost;User Id=beer2go;Password=Soccer_777",
            UseCache = true
        };

        public static readonly OrderDataConfiguration xmlConfiguration = new OrderDataConfiguration()
        {
            Type = eStorageType.Xml,
            FilePath = @"C:\Users\Nolan\Documents\Beer Truck Research\OrderDB.xml",
            UseCache = false
        };

        public static readonly OrderDataConfiguration mySqlConfiguration = new OrderDataConfiguration()
        {
            Type = eStorageType.MySql,
            ConnectionString = "Database=TheBar;Data Source=localhost;User Id=beer2go;Password=Soccer_777",
            UseCache = false
        };

        public static readonly OrderDataConfiguration sqlServerConfiguration = new OrderDataConfiguration()
        {
            Type = eStorageType.SqlServer,
            ConnectionString = @"server=.\SQLEXPRESS;initial catalog=TheBar;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework",
            UseCache = false
        };

        public static Order GetNewOrder()
        {
            return new Order()
            {
                Status = eOrderStatus.NEW,
                Latitude = 10,
                Longitude = 10,
                OrderedProducts = new List<ProductOrder>()
                {
                    new ProductOrder()
                    {
                        ProductID = 2,
                        Units = 5
                    }
                }
            };
        }

        public static Order GetCancelledOrder()
        {
            return new Order()
            {
                Status = eOrderStatus.CANCELLED,
                Latitude = 10,
                Longitude = 10,
                OrderedProducts = new List<ProductOrder>()
                {
                    new ProductOrder()
                    {
                        ProductID = 2,
                        Units = 5
                    }
                }
            };
        }

        public static Order GetDeliveredOrder()
        {
            return new Order()
            {
                Status = eOrderStatus.DELIVERED,
                Latitude = 10,
                Longitude = 10,
                OrderedProducts = new List<ProductOrder>()
                {
                    new ProductOrder()
                    {
                        ProductID = 2,
                        Units = 5
                    }
                }
            };
        }
    }
}
