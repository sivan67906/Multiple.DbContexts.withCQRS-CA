using Domain.DbContexts.Domain.Entities;
using Domain.DbContexts.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Multiple.DbContexts.Infrastructure.Data;

public class DomainMultipleDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    //CL:Aviv.Domain in model reduce the repetaion property into common folder class name baseentity
    //    //if base entiy need to work properly you need to config bellow
    //    foreach (var entity in base.ChangeTracker.Entries<BaseEntity>()
    //                            .Where(reqChange => reqChange.State == EntityState.Added || reqChange.State == EntityState.Modified))
    //    {
    //        entity.Entity.DateModified = DateTime.Now;

    //        if (entity.State == EntityState.Added)
    //        {
    //            entity.Entity.DateCreated = DateTime.Now;
    //        }
    //    }
    //    return base.SaveChangesAsync(cancellationToken);
    //}
}