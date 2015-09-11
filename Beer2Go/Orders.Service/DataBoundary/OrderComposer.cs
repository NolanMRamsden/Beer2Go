using Orders.Contracts;
using Orders.Contracts.Models;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orders.Service.DataBoundary
{
    public static class OrderComposer
    {
        public static OrderDto OrderDtoFromOrderModel(Order order)
        {
            if (order == null) return null;

            OrderDto dto = new OrderDto()
            {
                OrderId = order.OrderID,
                Latitude = order.Latitude,
                Longitude = order.Longitude,
                SubmittedAt = order.SubmittedAt,
                DeliveredAt = order.DeliveredAt,
                Status = (OrderStatus)OrderStatus.Parse(typeof(OrderStatus),order.Status.ToString(),true),
                Products = new List<ProductOrderDto>()
            };
            foreach (var product in order.OrderedProducts)
            {
                dto.Products.Add(new ProductOrderDto()
                    {
                        ProductID = product.ProductID,
                        Units = product.Units
                    });
            }
            return dto;
        }
    }
}