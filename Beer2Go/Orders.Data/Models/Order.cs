using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        public eOrderStatus Status { get; set; }

        [Required]
        public Decimal Latitude { get; set; }

        [Required]
        public Decimal Longitude { get; set; }

        public DateTime? SubmittedAt { get; set; }

        public DateTime? DeliveredAt { get; set; }

        public virtual List<ProductOrder> OrderedProducts { get; set; }
    }
}
