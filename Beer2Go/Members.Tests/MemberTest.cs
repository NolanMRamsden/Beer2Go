using Members.Data.Models;
using Members.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Tests
{
    public static class MemberTest
    {
        public static MemberDataConfiguration mySqlConfig = new MemberDataConfiguration()
        {
            Type = eStorageType.MySql,
            ConnectionString = "Database=TheTab;Data Source=localhost;User Id=beer2go;Password=Soccer_777",
            UseCache = false
        };
        public static MemberDataConfiguration sqlServerConfig = new MemberDataConfiguration()
        {
            Type = eStorageType.SqlServer,
            ConnectionString = @"server=.\SQLEXPRESS;initial catalog=TheTab;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework",
            UseCache = false
        };
        public static MemberDataConfiguration cacheConfig = new MemberDataConfiguration()
        {
            Type = eStorageType.MySql,
            ConnectionString = "Database=TheTab;Data Source=localhost;User Id=beer2go;Password=Soccer_777",
            UseCache = true
        };
        public static MemberDataConfiguration runTimeConfig = new MemberDataConfiguration()
        {
            Type = eStorageType.Runtime
        };

        public static Member GetMember()
        {
            return new Member()
            {
                Name = "Nolan Ramsden",
                PhoneNumber = "6042721430",
                LastLatitude = 0m,
                LastLongitude = 0m,
            };
        }

    }
}
