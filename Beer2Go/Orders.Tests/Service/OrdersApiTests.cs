using ApiConsumer.Requesters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Contracts;
using Orders.Contracts.Models;
using Orders.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.Service
{
    [TestClass]
    public class OrdersApiTests
    {
        const String urlAtTest = "http://beer2go-orders.azurewebsites.net/";

        IOrdersApi jsonApi;
        IOrdersApi xmlApi;

        [TestInitialize]
        public void SetUp()
        {
            jsonApi = new OrdersApi(urlAtTest, new JsonApiRequester());
            xmlApi = new OrdersApi(urlAtTest, new XmlRequester());
        }

        [TestMethod]
        public void OrdersSanityTest()
        {
            OrderDto dto = new OrderDto()
            {
                Latitude = 40,
                Longitude = 50,
                Products = new List<ProductOrderDto>()
                {
                    new ProductOrderDto()
                    {
                        ProductID = 5,
                        Units = 5
                    }
                }
            };

            int id = jsonApi.PutOrder(dto);

            Assert.IsNotNull(id , "Id return by inserting order was null");

            var returnedDto = jsonApi.GetOrder(id);

            Assert.AreEqual(id, returnedDto.OrderId);
            Assert.AreEqual(dto.Latitude, returnedDto.Latitude);
            Assert.AreEqual(dto.Longitude, returnedDto.Longitude);

            jsonApi.SetOrderStatus(id, OrderStatus.DELIVERED);

            returnedDto = jsonApi.GetOrder(id);

            Assert.AreEqual(id, returnedDto.OrderId);
            Assert.AreEqual(dto.Latitude, returnedDto.Latitude);
            Assert.AreEqual(dto.Longitude, returnedDto.Longitude);
            Assert.AreEqual(OrderStatus.DELIVERED, returnedDto.Status);
            Assert.IsNotNull(returnedDto.DeliveredAt);

            jsonApi.DeleteOrder(returnedDto.OrderId);
            var orders = jsonApi.GetActiveOrders();

            Assert.IsFalse(orders.Select(o => o.OrderId).Contains<int>(returnedDto.OrderId), 
                "returned list of orders contained deleted order");
        }
    }
}
