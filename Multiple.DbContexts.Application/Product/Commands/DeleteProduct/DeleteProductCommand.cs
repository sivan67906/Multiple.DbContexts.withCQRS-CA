using MediatR;

namespace Multiple.DbContexts.Application.Product.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
