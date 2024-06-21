using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Exceptions
{
    public class OrderAlreadyCancelledException : Exception
    {
        public OrderAlreadyCancelledException() : base("This order has already been cancelled.") { }
    }
}
