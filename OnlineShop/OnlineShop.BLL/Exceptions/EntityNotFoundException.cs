using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base() { }
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message, Exception e) : base(message, e) { }
        public EntityNotFoundException(string entityName, Guid id)
            : base($"Can't find entity of type {entityName} with ID {id}.") { }
    }
}
