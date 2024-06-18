using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException() : base() { }
        public RepositoryException(string message) : base(message) { }
        public RepositoryException(string message, Exception e) : base(message, e) { }

    }
}
