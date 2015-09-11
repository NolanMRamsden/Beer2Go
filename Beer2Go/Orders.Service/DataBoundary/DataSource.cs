using Orders.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orders.Service.DataBoundary
{
    public class DataSource
    {
        private static readonly IOrderData data;

        static DataSource()
        {
            data = DataLevelConfig.RegisterData();
        }

        public static IOrderData Data
        {
            get
            {
                if (data == null) DataLevelConfig.RegisterData();
                return data;
            }
        }
    }
}