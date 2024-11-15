using Domain.DbContexts.Domain.Interfaces;
using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;
using Multiple.DbContexts.Application.Product.Queries.GetProductById;
using System.Reflection.Metadata;

namespace Multiple.DbContexts.Application.Product.Queries.GetProducts;

public class GetProductsQueryHandler(IRepository<Domain.DbContexts.Domain.Entities.Product> repository)
    : IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
{
    public async Task<IEnumerable<ProductDTO>> Handle(
        GetProductsQuery request, CancellationToken cancellationToken)
    {
        var product = await repository.GetAllAsync();

        var productList = product.Select(x => new ProductDTO
        {
            Id = x.Id,
            Name = x.Name,
            Quantity = x.Quantity,
            Price = x.Price
        }).ToList();

        return productList;
    }
}
