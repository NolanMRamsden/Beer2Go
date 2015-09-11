using ApiConsumer.Requesters;
using FakeItEasy;
using NUnit;
using NUnit.Framework;
using Products.Data.Storage;
using Products.Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Products.Contracts.Tests
{
    [TestFixture]
    public class ProductServiceInvalidModelTests
    {
        IProductApi api;

        [TestFixtureSetUp]
        public void Init()
        {
            api = new ProductApi(Resources.UrlAtTest, new JsonApiRequester());
        }

        [Test]
        public void NegativeInventoryThrowsError()
        {
            var product = Resources.GetProductDto(6);
            product.Inventory = -2;

            try
            {
                api.StoreProduct(product);
                Assert.Fail();
            }catch(WebException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NegativeUnitQuantityThrowsError()
        {
            var product = Resources.GetProductDto(-1);

            try
            {
                api.StoreProduct(product);
                Assert.Fail();
            }
            catch (WebException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NoNameThrowsError()
        {
            var product = Resources.GetProductDto(1);
            product.Name = null;

            try
            {
                api.StoreProduct(product);
                Assert.Fail();
            }
            catch (WebException)
            {
                Assert.Pass();
            }
        }
    }
}
