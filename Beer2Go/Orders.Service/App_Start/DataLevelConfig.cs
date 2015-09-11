using Orders.Data.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Orders.Service
{
    public class DataLevelConfig
    {
        public static IOrderData RegisterData()
        {
            OrderConfigurationSection config = ConfigurationManager.GetSection("OrderDataSection") as OrderConfigurationSection;
            return OrderStorageFactory.GetOrderData(config.OrderDataSource);
        }
    }

    public sealed class OrderConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("OrderDataSource", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(OrderConfigurationSection))]
        public OrderDataConfiguration OrderDataSource
        {
            get
            {
                return (OrderDataConfiguration)base["OrderDataSource"];
            }
        }
    }
}