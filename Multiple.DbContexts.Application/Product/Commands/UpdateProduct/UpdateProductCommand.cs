using MediatR;
using Multiple.DbContexts.Application.Product.Queries.GetProductById;

namespace Multiple.DbContexts.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
