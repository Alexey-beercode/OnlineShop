﻿using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.DAL.Repositories.Implementations;

public class ProductRepository:IBaseRepository<Product>
{
    public Task CreateAsync(Product entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}