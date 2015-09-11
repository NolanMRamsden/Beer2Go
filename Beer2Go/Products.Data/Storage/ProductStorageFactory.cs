using Products.Data.Storage.Cache;
using Products.Data.Storage.MySql;
using Products.Data.Storage.Runtime;
using Products.Data.Storage.SqlServer;
using Products.Data.Storage.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Storage
{
    public class ProductStorageFactory
    {
        public static IProductData GetProductData(ProductDataConfiguration config)
        {
            if (config == null) throw new ArgumentNullException("config");
            IProductData dataStore;
            switch(config.Type)
            {
                case eStorageType.MySql:
                    dataStore = new MySqlProductData(config.ConnectionString);
                    break;
                case eStorageType.SqlServer:
                    dataStore = new SqlServerProductData(config.ConnectionString);
                    break;
                case eStorageType.Xml:
                    dataStore = new XmlProductData(config.FilePath);
                    break;
                case eStorageType.Runtime:
                    dataStore = new RuntimeProductData();
                    break;
                default:
                    throw new NotImplementedException(config.Type.ToString());
            }

            return config.UseCache ? new ProductCache(dataStore) : dataStore;
        }
    }
}
