using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Orders.Data.Storage
{
    public class OrderDataConfiguration : ConfigurationElement
    {
        public OrderDataConfiguration() { }

        [ConfigurationProperty("Type", IsRequired = true, IsKey = true)]
        public eStorageType Type
        {
            get { return (eStorageType)this["Type"]; }
            set { this["Type"] = value; }
        }

        [ConfigurationProperty("ConnectionString", DefaultValue = "", IsRequired = true, IsKey = false)]
        public string ConnectionString
        {
            get { return (string)this["ConnectionString"]; }
            set { this["ConnectionString"] = value; }
        }

        [ConfigurationProperty("FilePath", DefaultValue = "", IsRequired = true, IsKey = false)]
        public string FilePath
        {
            get { return (string)this["FilePath"]; }
            set { this["FilePath"] = value; }
        }

        [ConfigurationProperty("UseCache", DefaultValue = true, IsRequired = true, IsKey = false)]
        public Boolean UseCache
        {
            get { return (Boolean)this["UseCache"]; }
            set { this["UseCache"] = value; }
        }
    }

    public enum eStorageType
    {
        SqlServer, MySql, Xml, Runtime
    }
}
