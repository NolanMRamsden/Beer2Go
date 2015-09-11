using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleApi.Contracts.Models
{
    [Serializable]
    public class Location
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}
