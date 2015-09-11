using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Contracts.Models
{
    [Flags]
    public enum OrderStatus
    {
        NEW = 0,
        DELIVERED = 1,
        CANCELLED = 2
    }
}
