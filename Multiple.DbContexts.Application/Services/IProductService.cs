using Domain.DbContexts.Domain.Entities;
using Domain.DbContexts.Domain.Interfaces;

namespace Multiple.DbContexts.Application.Services
{
    public interface IProductService : IRepository<Product>
    {
    }
}
