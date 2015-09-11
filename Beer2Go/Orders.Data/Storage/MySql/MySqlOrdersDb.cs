using MySql.Data.Entity;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Storage.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal class MySqlOrdersDb : DbContext
    {
        internal MySqlOrdersDb(String connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }
    }
}
