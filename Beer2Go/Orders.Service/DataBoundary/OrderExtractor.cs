using Orders.Contracts;
using Orders.Contracts.Models;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orders.Service.DataBoundary
{
    public static class OrderExtractor
    {
        public static Order GetOrderFromDto(OrderDto order)
        {
            if (order == null) return null;

            Order o = new Order()
            {
                OrderID = order.OrderId,
                Latitude = order.Latitude,
                Longitude = order.Longitude,
                SubmittedAt = order.SubmittedAt,
                DeliveredAt = order.DeliveredAt,
                Status = !order.Status.HasValue ? eOrderStatus.NEW : (eOrderStatus)eOrderStatus.Parse(typeof(eOrderStatus),order.Status.ToString(),true),
                OrderedProducts = new List<ProductOrder>()
            };
            foreach (var product in order.Products)
            {
                o.OrderedProducts.Add(new ProductOrder()
                    {
                        OriginOrder = o,
                        Units = product.Units,
                        ProductID = product.ProductID
                    });
            }
            return o;
        }
    }
}