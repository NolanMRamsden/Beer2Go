using Members.Data.Storage.Cache;
using Members.Data.Storage.MySql;
using Members.Data.Storage.Runtime;
using Members.Data.Storage.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Data.Storage
{
    public static class MemberStorageFactory
    {
        public static IMemberData GetMemberData(MemberDataConfiguration config)
        {
            if (config == null) throw new ArgumentNullException("config");
            IMemberData dataStore;
            switch(config.Type)
            {
                case eStorageType.MySql:
                    dataStore = new MySqlMembersData(config.ConnectionString);
                    break;
                case eStorageType.SqlServer:
                    dataStore = new SqlServerMembersData(config.ConnectionString);
                    break;
                case eStorageType.Xml:
                    throw new NotImplementedException(config.Type.ToString());
                    break;
                case eStorageType.Runtime:
                    dataStore = new RuntimeMemberData();
                    break;
                default:
                    throw new NotImplementedException(config.Type.ToString());
            }

            return config.UseCache ? new MemberDataCache(dataStore) : dataStore;
        }
    }
}
