using Domain.DbContexts.Domain.Entities;
using Domain.DbContexts.Domain.Entities.Common;
using Domain.DbContexts.Domain.Interfaces;

namespace Multiple.DbContexts.Application.Services;

public class ProductService(IRepository<BaseEntity> repository) : IProductService
{
    public async Task<Product> AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }
}
