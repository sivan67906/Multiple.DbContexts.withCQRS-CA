using Domain.DbContexts.Domain.Entities.Common;

namespace Domain.DbContexts.Domain.Entities;

public class Order : BaseEntity
{
    public string? OrderName { get; set; }
    public DateTime OrderDate { get; set; }

    // Foreign Key
    public int ProductId { get; set; }

    // Navigation Property
    public Product? Product { get; set; }
}
