using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Orders.Data.Models
{
    public class ProductOrder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductOrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Units { get; set; }

        public virtual Order OriginOrder { get; set; }
    }
}
