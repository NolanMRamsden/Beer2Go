using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orders.Contracts.Models
{
    public class ProductOrderDto
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Product Id must be non-negative")]
        public int ProductID { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Order must specify how many units")]
        public int Units { get; set; }
    }
}