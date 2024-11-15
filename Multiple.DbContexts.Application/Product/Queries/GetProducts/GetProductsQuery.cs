using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Product.Queries.GetProducts;

public class GetProductsQuery : IRequest<IEnumerable<ProductDTO>>
{
}
