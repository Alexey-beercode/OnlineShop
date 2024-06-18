using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Exceptions
{
    public class EntityNotFoundException : RepositoryException
    {
        public EntityNotFoundException(string entityName, Guid id)
            : base($"Can't find entity of type {entityName} with ID {id}.") { }
    }
}
