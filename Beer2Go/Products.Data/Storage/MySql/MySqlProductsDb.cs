using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Data.Models;
using MySql.Data.Entity;
using System.Data.Entity;
using System.Data.Common;

namespace Products.Data.Storage.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal class MySqlProductsDb : DbContext
    {
        internal MySqlProductsDb(String connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
