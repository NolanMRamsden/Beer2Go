using Products.Data.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Products
{
    public class DataLevelConfig
    {
        public static IProductData RegisterData()
        {
            ProductConfigurationSection config = ConfigurationManager.GetSection("ProductDataSection") as ProductConfigurationSection;
            return ProductStorageFactory.GetProductData(config.ProductDataSource);
        }
    }

    public sealed class ProductConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("ProductDataSource", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ProductDataConfiguration))]
        public ProductDataConfiguration ProductDataSource
        {
            get
            {
                return (ProductDataConfiguration)base["ProductDataSource"];
            }
        }
    }
}