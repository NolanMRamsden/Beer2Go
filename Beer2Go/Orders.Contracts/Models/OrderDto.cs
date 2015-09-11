using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orders.Contracts.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public OrderStatus? Status { get; set; }

        [Required]
        [Range(-180,180, ErrorMessage = "Latitude must be between -180 and 180")]
        public Decimal Latitude { get; set; }

        [Required]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public Decimal Longitude { get; set; }

        public DateTime? SubmittedAt { get; set; }

        public DateTime? DeliveredAt { get; set; }

        public List<ProductOrderDto> Products { get; set; }
    }
}