using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Data.References
{
    public class AppSettingsServices : IServiceReferences
    {
        public String OrdersServiceUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["OrdersServiceUrl"].ToString();
            }
        }

        public string GoogleDirectionsApi
        {
            get
            {
                throw new NotImplementedException("Currently hard coded into googleApi.Contracts");
            }
        }
    }
}
