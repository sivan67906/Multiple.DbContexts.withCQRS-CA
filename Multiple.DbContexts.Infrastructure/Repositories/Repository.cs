using Domain.DbContexts.Domain.Entities.Common;
using Domain.DbContexts.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Multiple.DbContexts.Infrastructure.Data;

namespace Multiple.DbContexts.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DomainMultipleDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public Repository(DomainMultipleDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> UpdateAsync(int id, T entity)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }
}

