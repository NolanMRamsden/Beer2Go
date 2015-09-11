using System;
using System.Linq;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;
using System.Collections.Generic;
using System.Web.Http.Filters;
namespace Service.Common.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class RestrictDomainsAttribute : ActionFilterAttribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;

        public RestrictDomainsAttribute(List<String> domains)
        {
            Init(domains);
        }

        public RestrictDomainsAttribute(String appKey)
        {
            Init(appKey);
        }

        public RestrictDomainsAttribute()
        {
            Init("CorsGenericDomains");
        }

        private void Init(List<String> domains)
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };
            domains.ForEach(d => _policy.Origins.Add(d));
        }

        private void Init(String appKey)
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            string originsString = ConfigurationManager.AppSettings[appKey];
            if (!String.IsNullOrEmpty(originsString))
            {
                foreach (var origin in originsString.Split(','))
                {
                    _policy.Origins.Add(origin);
                }
            }
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request)
        {
            return Task.FromResult(_policy);
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}