using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Storage.SqlServer
{
    internal class SqlServerProductsDb : DbContext
    {
        internal SqlServerProductsDb(String connectionString) : base(connectionString)
        {
            
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    
        public virtual DbSet<Product> Products { get; set; }
    }
}
