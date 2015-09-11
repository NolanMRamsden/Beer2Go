using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.Models
{
    public class ProductDto
    {
        public int ProductID { get; set; }

        [Required]
        public String Name { get; set; }

        public String Description { get; set; }

        [Required]
        public Decimal PurchasePrice { get; set; }

        public Decimal SalePrice { get; set; }

        [Required]
        [Range(0,int.MaxValue, ErrorMessage = "Inventory must be non negative")]
        public int Inventory { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity per Unit (UnitQuantity) must be non negative")]
        public int UnitQuantity { get; set; }
    }
}
