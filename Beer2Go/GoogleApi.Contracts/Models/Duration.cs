using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleApi.Contracts.Models
{
    [Serializable]
    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }
}
