using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        [StringLength(100)]
        public String Description { get; set; }

        public Decimal PurchasePrice { get; set; }

        public Decimal SalePrice { get; set; }

        [Required]
        public int Inventory { get; set; }

        [Required]
        public int UnitQuantity { get; set; }
    }
}
