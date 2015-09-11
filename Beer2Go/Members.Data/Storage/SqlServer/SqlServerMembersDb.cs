using Members.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Data.Storage.SqlServer
{
    internal class SqlServerMembersDb : DbContext
    {
        internal SqlServerMembersDb(String connectionString) : base(connectionString)
        {
            
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberShip> Memberships { get; set; }
    }
}
