using Products.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Service.DataBoundary
{
    public class DataSource
    {
        private static readonly IProductData data;

        static DataSource()
        {
            data = DataLevelConfig.RegisterData();
        }

        public static IProductData Data
        {
            get
            {
                if (data == null) DataLevelConfig.RegisterData();
                return data;
            }
        }
    }
}