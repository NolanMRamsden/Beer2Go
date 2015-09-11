using Orders.Data.Storage.Cache;
using Orders.Data.Storage.MySql;
using Orders.Data.Storage.Runtime;
using Orders.Data.Storage.SqlServer;
using Orders.Data.Storage.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Storage
{
    public class OrderStorageFactory
    {
        public static IOrderData GetOrderData(OrderDataConfiguration config)
        {
            if (config == null) throw new ArgumentNullException("config");
            IOrderData dataStore;
            switch (config.Type)
            {
                case eStorageType.MySql:
                    dataStore = new MySqlOrderData(config.ConnectionString);
                    break;
                case eStorageType.SqlServer:
                    dataStore = new SqlServerOrderData(config.ConnectionString);
                    break;
                case eStorageType.Xml:
                    dataStore = new XmlOrderData(config.FilePath);
                    break;
                case eStorageType.Runtime:
                    dataStore = new RuntimeOrdersData();
                    break;
                default:
                    throw new NotImplementedException(config.Type.ToString());
            }

            return config.UseCache ? new OrderCache(dataStore) : dataStore;
        }
    }
}
