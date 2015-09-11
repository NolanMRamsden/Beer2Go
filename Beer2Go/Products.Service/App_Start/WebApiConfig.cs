using Microsoft.Practices.Unity;
using Products.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Products
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterInstance<IProductData>(DataLevelConfig.RegisterData(), new ContainerControlledLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            //Web API routing
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
