using Domain.DbContexts.Domain.Entities;
using Domain.DbContexts.Domain.Entities.Common;

namespace Domain.DbContexts.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<int> UpdateAsync(int id, T entity);
    Task<int> DeleteAsync(T entity);
}
