using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.Comparers
{
    public class OrderComparer : IEqualityComparer<Order>
    {
        public bool Equals(Order x, Order y)
        {
            if (x == null || y == null) return false;

            return x.OrderID == y.OrderID &&
                   x.Status == y.Status;
        }

        public int GetHashCode(Order obj)
        {
            return obj.OrderID;
        }
    }
}
