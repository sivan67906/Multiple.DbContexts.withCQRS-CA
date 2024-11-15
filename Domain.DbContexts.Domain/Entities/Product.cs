using Domain.DbContexts.Domain.Entities.Common;

namespace Domain.DbContexts.Domain.Entities;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    // Navigation Property
    public List<Order>? Orders { get; set; }
}
