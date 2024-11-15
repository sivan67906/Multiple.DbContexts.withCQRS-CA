using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Product.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductDTO>
{
    public int Id { get; set; }
}
