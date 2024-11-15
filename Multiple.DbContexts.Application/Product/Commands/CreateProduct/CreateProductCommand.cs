using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ProductDTO>
{
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
