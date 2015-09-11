using Members.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

namespace Members.Data.Storage.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal class MySqlMembersDb : DbContext
    {
        internal MySqlMembersDb(String connectionString) : base(connectionString)
        {
            
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberShip> Memberships { get; set; }
    }
}
