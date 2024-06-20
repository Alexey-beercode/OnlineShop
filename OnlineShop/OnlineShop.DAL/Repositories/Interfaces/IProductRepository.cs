using OnlineShop.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}
