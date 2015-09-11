using Products.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Tests
{
    public static class Settings
    {
        public static ProductDataConfiguration MySqlWithCacheConfig = new ProductDataConfiguration
        {
            Type = eStorageType.MySql,
            ConnectionString = "Database=TheVat;Data Source=localhost;User Id=beer2go;Password=Soccer_777",
            UseCache = true
        };

        public static ProductDataConfiguration MySqlWithoutCacheConfig = new ProductDataConfiguration
        {
            Type = eStorageType.MySql,
            ConnectionString = "Database=TheVat;Data Source=localhost;User Id=beer2go;Password=Soccer_777",
            UseCache = false
        };

        public static ProductDataConfiguration XmlWithoutCacheConfig = new ProductDataConfiguration
        {
            Type = eStorageType.Xml,
            FilePath = @"C:\Users\Nolan\Documents\Beer Truck Research\ProductDB.xml",
            UseCache = false
        };

        public static ProductDataConfiguration RuntimeConfig = new ProductDataConfiguration
        {
            Type = eStorageType.Runtime,
            UseCache = false
        };

        public static ProductDataConfiguration XmlWithCacheConfig = new ProductDataConfiguration
        {
            Type = eStorageType.Xml,
            FilePath = @"C:\Users\Nolan\Documents\Beer Truck Research\ProductDB.xml",
            UseCache = true
        };

        public static ProductDataConfiguration SqlServerWithCacheConfig = new ProductDataConfiguration
        {
            Type = eStorageType.SqlServer,
            ConnectionString = @"server=.\SQLEXPRESS;initial catalog=TheVat;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework",
            UseCache = true
        };

        public static ProductDataConfiguration SqlServerWithoutCacheConfig = new ProductDataConfiguration
        {
            Type = eStorageType.SqlServer,
            ConnectionString = @"server=.\SQLEXPRESS;initial catalog=TheVat;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework",
            UseCache = true
        };
    }
}
