using Domain.DbContexts.Domain.Interfaces;
using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Product.Queries.GetProductById;

public class GetProductByIdQueryHandler(
    IRepository<Domain.DbContexts.Domain.Entities.Product> repository)
    : IRequestHandler<GetProductByIdQuery, ProductDTO>
{
    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id);
        var entity = new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Quantity = product.Quantity,
            Price = product.Price
        };
        return entity;
    }
}
