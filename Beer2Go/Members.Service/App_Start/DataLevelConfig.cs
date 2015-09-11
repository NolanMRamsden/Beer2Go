using Members.Data.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Members.Service
{
    public class DataLevelConfig
    {
        public static IMemberData RegisterData()
        {
            MemberConfigurationSection config = ConfigurationManager.GetSection("MemberDataSection") as MemberConfigurationSection;
            return MemberStorageFactory.GetMemberData(config.MemberDataSource);
        }
    }

    public sealed class MemberConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("MemberDataSource", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(MemberConfigurationSection))]
        public MemberDataConfiguration MemberDataSource
        {
            get
            {
                return (MemberDataConfiguration)base["MemberDataSource"];
            }
        }
    }
}