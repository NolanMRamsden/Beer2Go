using Members.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Members.Service.DataBoundary
{
    public class DataSource
    {
        private static readonly IMemberData data;

        static DataSource()
        {
            data = DataLevelConfig.RegisterData();
        }

        public static IMemberData Data
        {
            get
            {
                if (data == null) DataLevelConfig.RegisterData();
                return data;
            }
        }
    }
}